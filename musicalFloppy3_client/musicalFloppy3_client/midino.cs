using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text;
using System.Windows.Forms;


namespace musicalFloppy3_client
{
    class midino
    {
        public ListBox debuglist;

        public SerialPort comPort
        {
            get;
            private set;
        }

        internal List<string> dataQueue;
        internal int maxTimeouts;
        internal int timeout;

        public midino(string comPort, ListBox dbglst)
        {
            this.dataQueue = new List<string>();
            this.maxTimeouts = 10;
            this.timeout = 5;

            this.comPort = new SerialPort(comPort, 9600, Parity.None, 8);
            this.debuglist = dbglst;
        }

        public void playFrequency(int channel, double frequency)
        {
            comPort.Write(channel + ":" + frequency + ";");
        }

        public bool connect()
        {
            try
            {
                comPort.Open();
                comPort.DataReceived += this.dataReceived;
            }
            catch (Exception ex)
            {
                return false;
            }

            return hasValidSoftware();
        }

        public void disconnect()
        {
            comPort.BaseStream.Flush();
            Thread.Sleep(100);
            comPort.Close();
        }

        public void reset()
        {
            comPort.Write("backtozero;");
        }

        public void test()
        {
            comPort.Write("test;");
        }

        private bool hasValidSoftware()
        {
            comPort.Write("software?;");

            string software = "";
            for (int i = 0; i < maxTimeouts; i++)
            {
                Thread.Sleep(timeout);
                foreach (string entry in dataQueue)
                {
                    if (entry.StartsWith("software"))
                    {
                        software = entry.Split(':')[1];
                        dataQueue.Remove(entry);
                        break;
                    }
                }
                if (software != "")
                {
                    break;
                }
            }

            if (software == "mfloppy3")
            {
                return true;
            }
            else return false;
        }

        internal void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = comPort.ReadLine().Trim();
            this.dataQueue.Add(data);
            debuglist.Items.Add(data);
        }
    }
}
