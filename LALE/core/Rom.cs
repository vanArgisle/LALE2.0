using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    public class ROM
    {
        byte[] buffer;
        int bufferLocation = 0;
        public string Filename { get; set; }

        public byte[] Buffer
        {
            get {
				byte[] bufferCopy = new byte[buffer.Length];
				for (int i = 0; i < buffer.Length; i++)
					bufferCopy[i] = buffer[i];
				
				return bufferCopy; 
			}
            set { buffer = value; }
        }

		public int BufferLocation
		{
			get { return bufferLocation; }
			set
			{
				if (value > buffer.Length)
				{
					throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
				}
				bufferLocation = value;
			}
		}

		public ROM(byte[] ExistingBuffer, string filename = "")
		{
			buffer = ExistingBuffer;
			Filename = filename;
		}


		//Below here are our Gameboy ROM operations like reading and writing bytes from and to the buffer

		public byte WriteByte(byte Value)
		{
			if (bufferLocation > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			buffer[bufferLocation++] = Value;
			return Value;
		}

		public byte[] WriteBytes(byte[] Value)
		{
			if (bufferLocation + Value.Length > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			foreach (byte n in Value)
				buffer[bufferLocation++] = n;
			return Value;
		}

		public UInt16 WriteWord(UInt16 Value)
		{
			if (bufferLocation + 1 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			buffer[bufferLocation++] = (byte)(Value >> 8);
			buffer[bufferLocation++] = (byte)Value;
			return Value;
		}

		public UInt32 WriteDWord(UInt32 Value)
		{
			if (bufferLocation + 3 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			buffer[bufferLocation++] = (byte)(Value >> 24);
			buffer[bufferLocation++] = (byte)(Value >> 16);
			buffer[bufferLocation++] = (byte)(Value >> 8);
			buffer[bufferLocation++] = (byte)Value;
			return Value;
		}

		public UInt64 WriteQWord(UInt64 Value)
		{
			if (bufferLocation + 7 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			buffer[bufferLocation++] = (byte)(Value >> 56);
			buffer[bufferLocation++] = (byte)(Value >> 48);
			buffer[bufferLocation++] = (byte)(Value >> 40);
			buffer[bufferLocation++] = (byte)(Value >> 32);
			buffer[bufferLocation++] = (byte)(Value >> 24);
			buffer[bufferLocation++] = (byte)(Value >> 16);
			buffer[bufferLocation++] = (byte)(Value >> 8);
			buffer[bufferLocation++] = (byte)Value;
			return Value;
		}

		public byte ReadByte()
		    {
			 if (bufferLocation > buffer.Length - 1)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			  return buffer[bufferLocation++];
		  }

		public UInt16 ReadWord()
		{
			if (bufferLocation + 1 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			bufferLocation += 2;
			return (UInt16)(((buffer[bufferLocation - 2] & 0xff) << 8) + (buffer[bufferLocation - 1] & 0xff));
		}

		public UInt32 ReadDWord()
		{
			if (bufferLocation + 3 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			bufferLocation += 4;
			return (UInt32)(((buffer[bufferLocation - 4] & 0xff) << 24) + ((buffer[bufferLocation - 3] & 0xff) << 16) + ((buffer[bufferLocation - 2] & 0xff) << 8) + (buffer[bufferLocation - 1] & 0xff));
		}

		public UInt64 ReadQWord()
		{
			if (bufferLocation + 7 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			long i = ReadDWord() & 0xffffffffL;
			long j = ReadDWord() & 0xffffffffL;
			return (UInt64)((i << 32) + j);
		}

		public byte PeakByte()
		{
			if (bufferLocation > buffer.Length - 1)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			return buffer[bufferLocation];
		}

		//More common methods
		public byte WriteByte(int Location, byte Value)
		{
			if (bufferLocation > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			WriteByte(Value);
			return Value;
		}

		public byte[] WriteBytes(int Location, byte[] Value)
		{
			if (bufferLocation + Value.Length > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			foreach (byte b in Value)
				WriteByte(b);
			return Value;
		}

		public UInt16 WriteWord(int Location, UInt16 Value)
		{
			if (bufferLocation + 1 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			WriteWord(Value);
			return Value;
		}

		public UInt32 WriteDWord(int Location, UInt32 Value)
		{
			if (bufferLocation + 3 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			WriteDWord(Value);
			return Value;
		}

		public UInt64 WriteQWord(int Location, UInt64 Value)
		{
			if (bufferLocation + 7 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The new buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			WriteQWord(Value);
			return Value;
		}

		public byte ReadByte(int Location)
		{
			if (bufferLocation > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			return ReadByte();
		}

		public UInt16 ReadWord(int Location)
		{
			if (bufferLocation + 1 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			return ReadWord();
		}

		public UInt32 ReadDWord(int Location)
		{
			if (bufferLocation + 3 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			return ReadDWord();
		}

		public UInt64 ReadQWord(int Location)
		{
			if (bufferLocation + 7 > buffer.Length)
			{
				throw new IndexOutOfRangeException("The buffer location is beyond the length of the buffer.");
			}
			bufferLocation = Location;
			return ReadQWord();
		}

		//Other
		public byte[] ReadBytes(int Count)
		{
			byte[] bytes = new byte[Count];
			for (int i = 0; i < Count; i++)
			{
				bytes[i] = ReadByte();
			}
			return bytes;
		}

		public byte[] ReadBytes(int Location, int Count)
		{
			bufferLocation = Location;
			byte[] bytes = new byte[Count];
			for (int i = 0; i < Count;   i++)
			{
				  bytes[i] = ReadByte();
			}
			return bytes;
		 }

		public byte[] Get2BytePointer(int Address)
		{
			byte[] value = new byte[2];
			int bank = (Address / 0x4000) * 0x4000;
			int ByteAddress = Address - bank;
			value[0] = (byte)(ByteAddress / 0x100);
			if (value[0] < 0x40)
				value[0] += 0x40;
			while (value[0] > 0x7F)
				value[0] -= 0x40;
			value[1] = (byte)(ByteAddress - value[0] * 0x100);
			value[1] ^= value[0];
			value[0] ^= value[1];
			value[1] ^= value[0];
			return value;
		}

		public int Get2BytePointerAtAddress(int Address)
		{
			int bank = (Address / 0x4000) * 0x4000;
			byte[] bytePointer = this.ReadBytes(Address, 2);

			return ((bytePointer[1] * 0x100) + bytePointer[0]) - 0x4000 + bank;

		}
		public byte[] Get3BytePointer(int Address)
		{
			byte[] value = new byte[3];
			int bank = (Address / 0x4000) * 0x4000;
			int ByteAddress = Address - bank;
			value[0] = (byte)(Address / 0x100);
			if (value[0] < 0x40)
				value[0] += 0x40;
			while (value[0] > 0x7F)
				value[0] -= 0x40;
			value[1] = (byte)(Address - value[0] * 0x100);
			value[1] ^= value[0];
			value[0] ^= value[1];
			value[1] ^= value[0];
			value[2] = (byte)(Address / 0x4000);
			return value;
		}

		public int Get3BytePointerAtAddress(int Address)
		{
			int bank = (Address / 0x4000) * 0x4000;
			byte[] bytePointer = this.ReadBytes(Address, 3);

			return ((bytePointer[1] * 0x100) + bytePointer[0]) - 0x4000 + (bytePointer[2] * 0x4000);

		}

		public System.Drawing.Color GetColor(UInt16 Value)
		{
			byte red = (byte)((Value & 31));
			Value >>= 5;
			byte green = (byte)((Value & 31));
			Value >>= 5;
			byte blue = (byte)((Value & 31));
			return System.Drawing.Color.FromArgb(red, green, blue);
		}

		public System.Drawing.Color GetRealColor(UInt16 Value)
		{
			int r = Value & 31;
			int g = (Value / 32) & 31;
			int b = (Value / 1024) & 31;

			return System.Drawing.Color.FromArgb(r * 8, g * 8, b * 8);
		}

		public System.Drawing.Color GetColor(int Address)
		{
			return GetColor(ReadWord(Address));
		}

		public System.Drawing.Color GetRealColor(int Address)
		{
			UInt16 value = (UInt16)(ReadByte(Address) + (ReadByte() << 8));
			return GetRealColor(value);
		}

		public System.Drawing.Color[,] GetPalette(int Address)
		{
			System.Drawing.Color[,] colors = new System.Drawing.Color[8, 4];
			bufferLocation = Address;
			for (int i = 0; i < 8; i++)
			{
				for (int k = 0; k < 4; k++)
				{
					colors[i, k] = GetRealColor(bufferLocation);
				}
			}
			return colors;
		}

		public void WritePalette(System.Drawing.Color[,] palette)
        {
			int r, g, blu;

			for (int k = 0; k < 8; k++)
			{
				for (int i = 0; i < 4; i++)
				{
					r = palette[k, i].R / 8;
					g = palette[k, i].G / 8;
					blu = palette[k, i].B / 8;
					blu *= 4;
					g *= 2;

					blu *= 256;
					g *= 16;
					int value = r + g + blu;
					WriteByte((byte)(value & 0xFF));
					WriteByte((byte)(value >> 8));
				}
			}
		}

		//Not mine
		public void ReadTiles(int width, int height, int offset, ref byte[,,] target)
		{
			ReadTiles(width, height, 0, offset, ref target);
		}
		public void ReadTiles(int width, int height, int yOff, int offset, ref byte[,,] target)
		{
			int curOffset = offset;
			for (int j = 0; j < height; ++j)
			{
				if (j + yOff > 15)
					yOff -= 16;
				for (int i = 0; i < width; ++i)
				{
					for (int y2 = 0; y2 < 8; ++y2)
					{
						byte byte1 = ReadByte(curOffset++);
						byte byte2 = ReadByte(curOffset++);
						for (int x2 = 7; x2 >= 0; --x2)
						{
							target[i + (j + yOff) * width, x2, y2] = (byte)((byte1 & 1) + (byte2 & 1) * 2);
							byte1 >>= 1;
							byte2 >>= 1;
						}
					}
				}
			}
		}
		public void ReadTiles(int width, int height, byte[] bytes, ref byte[,,] target)
		{
			ROM gbf = new ROM(bytes);
			int curOffset = 0;
			for (int j = 0; j < height; ++j)
			{
				for (int i = 0; i < width; ++i)
				{
					for (int y2 = 0; y2 < 8; ++y2)
					{
						byte byte1 = gbf.ReadByte(curOffset++);
						byte byte2 = gbf.ReadByte(curOffset++);
						for (int x2 = 7; x2 >= 0; --x2)
						{
							target[i + j * width, x2, y2] = (byte)((byte1 & 1) + (byte2 & 1) * 2);
							byte1 >>= 1;
							byte2 >>= 1;
						}
					}
				}
			}
		}
	}
}
