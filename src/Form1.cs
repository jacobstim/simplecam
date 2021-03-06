﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectX.Capture;
using System.Runtime.InteropServices;
using DShowNET;

namespace MyWebCam
{
    public partial class Form1 : Form
    {
        /* Muaz Khan (@muazkh) - http://muaz-khan.blogspot.com */

        Capture capture = null;
        Filters filters = null;

        Point oldPos;
        Size oldSize;

        Size frameSize = new Size(640,480);                             // Default is 640x480

        int deviceNumber = 0;

        List<Button> btnArray = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }


        /*============================================================================*/


        private void Form1_Shown(object sender, EventArgs e)
        {
            // Ensure panel is at the correct location for this Form configuration
            //panel1.Location = new Point(0, menuStrip1.Size.Height);
            //panel1.Width = this.Width;
            //panel1.Height = this.ClientSize.Height - menuStrip1.Size.Height;
            positionSizePanel();

            filters = new Filters();

            if (filters.VideoInputDevices == null)
            {
                MessageBox.Show("No video device connected to your PC!");
            }

            if (filters.VideoInputDevices != null)
            {
                // Create a button for every possible input source
                for (var i = 0; i < filters.VideoInputDevices.Count; i++)
                {
                    var device = filters.VideoInputDevices[i];

                    var btn = new Button();

                    btn.Text = i.ToString();
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.DarkSlateBlue;
                    btn.Width = 25;
                    btn.Location = new Point(10+30*i, resolutionBox.Location.Y);
                    btn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

                    btn.Click += (obj, evt) =>
                    {
                        var thisButton = (Button)obj;

                        if (int.Parse(thisButton.Text) != deviceNumber)
                        {
                            deviceNumber = int.Parse(thisButton.Text);
                            changeCamera(deviceNumber);
                        }
                    };
                    btnArray.Add(btn);
                }

                // Add all buttons to the Form
                for (var i = 0; i < btnArray.Count; i++)
                {
                    this.Controls.Add(btnArray[i]);
                    btnArray[i].BringToFront();
                    btnArray[i].Visible = true;
                }
                // Make sure we never graphically mess up the buttons
                this.MinimumSize = new Size(50+ resolutionBox.Size.Width + btnArray.Count*30, 100);

                // Start with preview
                changeCamera(deviceNumber);
            }

        }

        /*============================================================================*/

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            positionSizePanel();
        }


      /*============================================================================
        Calculate position & size of video panel based on settings & environment
        ============================================================================ */

        private void positionSizePanel()
        {
            // Calculate width & height that we can maximally occupy
            int availableHeight = this.ClientSize.Height;
            int availableWidth = this.ClientSize.Width;
            int offsetHeight = 0;
            int offsetWidth = 0;

            if (!minimalisticStyleToolStripMenuItem.Checked)
            {
                // Standard mode, take into account menu bar that is visible, so we have less available height & we need to shift panel down using offset
                offsetHeight = menuStrip1.Size.Height;
                availableHeight -= offsetHeight;
            }

            // Maintain aspect ratio?
            if (maintainAspectRatioToolStripMenuItem.Checked)
            {
                // Calculate aspect ratio of source
                float aspectRatio = (float)frameSize.Width / frameSize.Height;

                // Do we need to create horizontal or vertical bars?
                if (availableHeight * aspectRatio < availableWidth)
                {
                    // There is enough width to maintain the aspect ratio of the source
                    if (scaleToFitWindowToolStripMenuItem.Checked)
                    {
                        float scalingFactor = (float)frameSize.Height / availableHeight;
                        int newWidth = (int)Math.Floor((float)frameSize.Width / scalingFactor);
                        // Create vertical bars
                        panel1.Location = new Point((availableWidth - newWidth) / 2, offsetHeight);
                        panel1.Width = newWidth;
                        panel1.Height = availableHeight;

                    }
                    else
                    {
                        float scalingFactor = (float)frameSize.Width / availableWidth;
                        int newHeight = (int)Math.Floor((float)frameSize.Height / scalingFactor);
                        // NO scale to fit, so we need to shift the video VERTICALLY (Y) to the center of the window
                        // i.e. zoom panel
                        panel1.Location = new Point(0, offsetHeight + (availableHeight - newHeight) / 2);
                        panel1.Width = availableWidth;
                        panel1.Height = newHeight;
                    }
                }
                else
                {
                    // There is not enough width to maintain the aspect ratio of the source
                    if (scaleToFitWindowToolStripMenuItem.Checked)
                    {
                        float scalingFactor = (float)frameSize.Width / availableWidth;
                        int newHeight = (int)Math.Floor((float)frameSize.Height / scalingFactor);
                        // NO scale to fit, so we need to shift the video VERTICALLY (Y) to the center of the window
                        // i.e. zoom panel
                        panel1.Location = new Point(0, offsetHeight + (availableHeight - newHeight) / 2);
                        panel1.Width = availableWidth;
                        panel1.Height = newHeight;
                    }
                    else
                    {
                        float scalingFactor = (float)frameSize.Height / availableHeight;
                        int newWidth = (int)Math.Floor((float)frameSize.Width / scalingFactor);
                        // Create horizontal bars
                        panel1.Location = new Point((availableWidth - newWidth) / 2, offsetHeight);
                        panel1.Width = newWidth;
                        panel1.Height = availableHeight;
                    }


                }

            }
            else
            {
                // Just rescale panel
                panel1.Location = new Point(0, offsetHeight);
                panel1.Width = availableWidth;
                panel1.Height = availableHeight;
            }
            panel1.Refresh();
        }


        /*============================================================================*/

        private void resolutionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] selectSize = new String[2];

            // Get framesize to use
            if (resolutionBox.SelectedItem != null)
            {
                if (resolutionBox.SelectedItem.ToString().Length > 0)
                {
                    selectSize = (resolutionBox.SelectedItem.ToString().Split(' '))[0].Split('x');
                }
            }

            int xSize = 0;
            int ySize = 0;
            if (Int32.TryParse(selectSize[0], out xSize))
            {
                if (Int32.TryParse(selectSize[1], out ySize))
                {
                    frameSize = new Size(xSize, ySize);
                    // Stop current preview
                    stopPreview();
                    // Start again with the new resolution
                    preview(deviceNumber);
                }
            }



        }

        /*============================================================================
          Change active display to camera X
          ============================================================================ */

        void changeCamera(int deviceNo)
        {
            stopPreview();
            fillResolutions(deviceNo);
            preview(deviceNo);
        }

        /*============================================================================
          Start video display for camera X
          ============================================================================ */

        void preview(int deviceNo)
        {
            try
            {
                capture = new Capture(filters.VideoInputDevices[deviceNo], filters.AudioInputDevices[0]);

                // Default value
                capture.FrameSize = new Size(640, 480);
                if (frameSize != null)
                {
                    if ((frameSize.Width > 0) && (frameSize.Height > 0))
                    {
                        // Default value
                        capture.FrameSize = frameSize;
                    }
                }
                capture.PreviewWindow = panel1;

                //capture.Filename = ...                // If you need recording to disk... 
                //capture.Start();                                              
            }
            catch {
                // Something went wrong, clean up
                if (capture != null)
                {
                    capture.Dispose();
                    capture.Stop();
                    capture.PreviewWindow = null;
                }
            }
        }

        private void stopPreview()
        {
            if (capture != null)
            {
                capture.Dispose();
                capture.Stop();
                capture.PreviewWindow = null;
            }
        }

        /*============================================================================
           Get supported resolutions for camera X and update UI
           ============================================================================ */

        private void fillResolutions(int deviceNo)
        {
            // Remove event handler to prevent resolutionBox changed code going haywire... 
            resolutionBox.SelectedIndexChanged -= resolutionBox_SelectedIndexChanged;
            resolutionBox.Enabled = false;
            resolutionBox.Items.Clear();
            // Combobox with resolutions - hardcoded for now
            resolutionBox.Items.Add("640x480 (30)");
            resolutionBox.Items.Add("800x600 (30)");
            resolutionBox.Items.Add("1024x768 (15)");
            resolutionBox.Items.Add("1280x1024 (8)");
            resolutionBox.Items.Add("1600x1200 (4)");
            resolutionBox.SelectedIndex = 0;                    // Default is 640x480
            resolutionBox.Enabled = true;
            // Add eventhandler again
            resolutionBox.SelectedIndexChanged += resolutionBox_SelectedIndexChanged;

        }



      /*============================================================================
        Menu activities
        ============================================================================ */

        private void toggleAlwaysOnTop(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void toggleWindowStyle(object sender, EventArgs e)
        {
            this.SuspendLayout();

            Boolean newState = !minimalisticStyleToolStripMenuItem.Checked;
            minimalisticStyleToolStripMenuItem.Checked = newState;
            if (newState) {
                // Store current window size & position
                oldPos = this.Location;
                oldSize = this.Size;

                // Ensure that webcam view stays on the same location -> new window has to match the current's panel position
                Rectangle rcPanel = panel1.RectangleToScreen(panel1.ClientRectangle);
                Rectangle rcForm = RectangleToScreen(this.ClientRectangle);

                // Check if we are showing the entire panel, or if clipping occurs
                if ((panel1.Left >= 0) && (panel1.Top >= 0))
                {
                    // No clipping, so new location & size of the FORM are equal to that of the PANEL
                    this.Location = new Point(rcPanel.Left, rcPanel.Top);
                    this.ClientSize = new Size(rcPanel.Width, rcPanel.Height);     // This triggers a repositioning of the panel through the resize event
                } else
                {
                    // Clipping occurs, so new location & size of the FORM are that of the current form for the clipped direction
                    if (panel1.Left < 0)
                    {
                        // We are clipping in the HORIZONTAL direction
                        this.Location = new Point(rcForm.Left, rcPanel.Top);
                        this.ClientSize = new Size(rcForm.Width, rcPanel.Height);
                    }
                    else
                    {
                        // We are clipping in the VERTICAL direction
                        this.Location = new Point(rcPanel.Left, rcForm.Top + menuStrip1.Height);
                        this.ClientSize = new Size(rcPanel.Width, rcForm.Height - menuStrip1.Height);
                    }
                }

                //this.Size = new Size(this.Width, this.Height - menuStrip1.Size.Height);     // This triggers a repositioning of the panel through the resize event
                //this.Location = new Point(this.Location.X + (this.Size.Width - this.ClientSize.Width - 2* SystemInformation.Border3DSize.Width -1), this.Location.Y + (this.Size.Height - this.ClientSize.Height - 2*SystemInformation.Border3DSize.Height) -1);

                this.FormBorderStyle = FormBorderStyle.None;

                menuStrip1.Visible = false;
                resolutionBox.Visible = false;

                // Hide all buttons
                for (var i = 0; i < btnArray.Count; i++)
                {
                    btnArray[i].Visible = false;
                }
            }
            else
            {
                // Restore window size & position
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = oldPos;
                this.Size = oldSize;                // This triggers a repositioning of the panel through the resize event
                menuStrip1.Visible = true;
                resolutionBox.Visible = true;
                // Show all buttons
                for (var i = 0; i < btnArray.Count; i++)
                {
                    btnArray[i].Visible = true;
                }
            }
            this.ResumeLayout();
        }

        private void toggleAspectRatio(object sender, EventArgs e)
        {
            maintainAspectRatioToolStripMenuItem.Checked = !maintainAspectRatioToolStripMenuItem.Checked;
            positionSizePanel();
        }

        private void toggleScaleToFit(object sender, EventArgs e)
        {
            scaleToFitWindowToolStripMenuItem.Checked = !scaleToFitWindowToolStripMenuItem.Checked;
            positionSizePanel();
        }


        private void aboutWindow(object sender, EventArgs e)
        {
            MessageBox.Show("SimpleCam v1.1" + Environment.NewLine + Environment.NewLine + "Written in 2016 by Tim Jacobs" + Environment.NewLine,"SimpleCam v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitProgram(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}