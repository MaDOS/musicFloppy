using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;

namespace musicalFloppy3_client
{
    public partial class Form1 : Form
    {
        midino floppies;
        Sequence midi;
        Sequencer sequencer;
        Dictionary<int, double> frequencies = new Dictionary<int, double>();

        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            cmbBoxPorts.Items.AddRange(SerialPort.GetPortNames());
            sequencer = new Sequencer();
            sequencer.ChannelMessagePlayed += new EventHandler<ChannelMessageEventArgs>(sequencer_ChannelMessagePlayed);
            sequencer.PlayingCompleted += new EventHandler(sequencer_PlayingCompleted);
            int max = 49;
            for (int i = 1; i < max; i++)
            {
                frequencies.Add(i+20, getFrequency(i));
            }
        }

        void sequencer_PlayingCompleted(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            floppies.reset();
        }

        public double getFrequency(int key)
        {
            double solution;
            double power = key - 49;
            double root = NRoot(2, 12);
            double fac = Math.Pow(root, power);
            solution = 440 * fac;
            return solution;
        }

        double NRoot(double x, double n)
        {
            return Math.Pow(x, 1.0 / n);
        }

        void  sequencer_ChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            ChannelMessage msg = e.Message;
            if (msg.Command == ChannelCommand.NoteOn)
            {
                try
                {
                    floppies.playFrequency(msg.MidiChannel, frequencies[msg.Data1]);
                }
                catch (Exception ex)
                { }
            }
            else if (msg.Command == ChannelCommand.NoteOff)
            {
                floppies.playFrequency(msg.MidiChannel, 0);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            floppies = new midino(cmbBoxPorts.SelectedItem.ToString(), this.lstBxOutput);
            if (floppies.connect())
            {
                floppies.reset();
                floppies.test();
            }
        }

        private void btnSetFrequency_Click(object sender, EventArgs e)
        {
            double frequency = Convert.ToDouble(this.txtBxFreq.Text);
            floppies.playFrequency(0, frequency);
            floppies.playFrequency(1, frequency);
            floppies.playFrequency(2, frequency);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                floppies.reset();
                floppies.disconnect();
            }
            catch (Exception ex)
            { }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            floppies.test();
        }

        private void btnBackToZero_Click(object sender, EventArgs e)
        {
            floppies.reset();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtMidiPath.Text = ofd.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            midi = new Sequence(this.txtMidiPath.Text);
            sequencer.Sequence = midi;
            sequencer.Start();
        }

        private void btnPauseMidi_Click(object sender, EventArgs e)
        {
            sequencer.Stop();
        }

        private void btnContinueMidi_Click(object sender, EventArgs e)
        {
            sequencer.Continue();
        }
    }
}
