using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace musicalFloppy3_client
{
    public sealed class midiFile
    {
        byte[] VALID_HEADER_CHUNK = { 0x4D, 0x54, 0x68, 0x64, 0x00, 0x00, 0x00, 0x06 };
        byte[] VALID_TRACK_CHUNK = { 0x4D, 0x54, 0x72, 0x6B};
        byte NOTE_ON = 0x90;
        byte NOTE_OFF = 0x80;

        public string Path
        {
            get;
            private set;
        }

        public MidiFormat Format
        {
            get;
            private set;
        }

        public ushort TrackCount
        {
            get;
            private set;
        }

        public short QuarterNoteDelta
        {
            get;
            private set;
        }

        private byte[] bytes;

        private Dictionary<int, byte[]> tracks;



        public midiFile(string path) 
        {
            this.Path = path;
            this.tracks = new Dictionary<int, byte[]>();
            this.loadMidi();
        }

        private void loadMidi()
        {
            FileStream fs = new FileStream(this.Path, FileMode.Open);

            //Verify file
            byte[] headerChunk = new byte[8];
            fs.Read(headerChunk, 0, 8);

            if (!headerChunk.SequenceEqual(VALID_HEADER_CHUNK))
            {
                throw new invalidMidiFileException();
                return;
            }

            //read header info
            byte[] midiFormat = new byte[2];
            fs.Read(midiFormat, 0, 2);
            Array.Reverse(midiFormat); //little to big endian

            byte[] trackCount = new byte[2];
            fs.Read(trackCount, 0, 2);
            Array.Reverse(trackCount);

            byte[] quarterNoteDelta = new byte[2];
            fs.Read(quarterNoteDelta, 0, 2);
            Array.Reverse(quarterNoteDelta);

            this.TrackCount = BitConverter.ToUInt16(trackCount, 0);
            this.Format = (MidiFormat)BitConverter.ToInt16(midiFormat, 0);
            this.QuarterNoteDelta = BitConverter.ToInt16(quarterNoteDelta, 0);


            for (int trackI = 1; trackI <= this.TrackCount; trackI++)
            {
                byte[] trackChunk = new byte[4];
                fs.Read(trackChunk, 0, 4);

                if (!trackChunk.SequenceEqual(VALID_TRACK_CHUNK))
                {
                    throw new invalidMidiFileException();
                }

                byte[] btTrackLength = new byte[4];
                fs.Read(btTrackLength, 0, 4);
                Array.Reverse(btTrackLength);

                int trackLength = BitConverter.ToInt32(btTrackLength, 0);

                byte[] track = new byte[trackLength];
                fs.Read(track, 0, trackLength);

                this.tracks.Add(trackI, track);
            }

            fs.Close();
        }

        public enum MidiFormat
        {
            singleTrack,
            multiTrackSync,
            multiTrackAsync
        }

        class invalidMidiFileException : Exception
        {
            public invalidMidiFileException()
            { }
        }
    }
}
