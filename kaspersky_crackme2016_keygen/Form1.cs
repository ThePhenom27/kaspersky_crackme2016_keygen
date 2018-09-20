using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace kaspersky_crackme2016_keygen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		byte[] kaspersky_algo(string pass)
		{
			uint block1 = BitConverter.ToUInt32(StringToByteArray(pass.Substring(0, 8)), 0);
			uint block2 = BitConverter.ToUInt32(StringToByteArray(pass.Substring(8, 8)), 0);
			uint block3 = BitConverter.ToUInt32(StringToByteArray(pass.Substring(16, 8)), 0);
			uint block4 = BitConverter.ToUInt32(StringToByteArray(pass.Substring(24, 8)), 0);


			uint v5 = block1 & 0xFF0000;     // //algo start for pass
			uint v6 = (((block1 >> 16) | v5) >> 8);
			uint v7 = block1 << 16;
			byte[] block1_byte_array = BitConverter.GetBytes(((block1 & 0xFF00 | v7) << 8) | v6) ;// 1 block assigned

			uint v8 = block2 & 0xFF0000;
			uint v9 = (((block2) >> 16) | v8) >> 8;
			uint v10 = block2 << 16;
			byte[] block2_byte_array = BitConverter.GetBytes((block2 & 0xFF00 | v10 << 8) | v9);// 2 block assigned
			uint v11 = block3 & 0xFF0000;
			uint v12 = ((block3 >> 16) | v11) >> 8;
			uint v13 = block3 << 16;
			//uint v14 = (int)(v2 + 24);
			byte[] block3_byte_array = BitConverter.GetBytes(((block3 & 0xFF00 | v13) << 8) | v12);// 3 block assigned
			uint v15 = block4 & 0xFF0000;
			uint v16 = ((block4 >> 16) | v15) >> 8;
			uint v17 = block4 << 16;
			byte[] block4_byte_array = BitConverter.GetBytes(((block4 & 0xFF00 | v17) << 8) | v16);// 4 block assigned

			return block1_byte_array.Concat(block2_byte_array).Concat(block3_byte_array).Concat(block4_byte_array).ToArray();


		}


		//byte[] StringToByteArray(string str)
		//{
		//	byte[] result = new byte[str.Length];
		//	foreach (var p in str.Split(' ').Select((element, index) => new { element,index }) )
		//	{
		//		result[p.index] = Convert.ToByte(p.element);
		//	}
		//	return result;
		//}

		public static byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}


		string[] HardcodedHashes = {
				"CD64341F68CEDE586C9693EDC505F378",
				"05D34B65E96F1D39CCB584C00372D8A3",
				"A15B7EBAAD915326241DFB5B1BBC546F",
				"3BA00294E441051554FD64A729114FC9",
				"8D0AA0050DC9D654200A3D1649DE9D36" };

		MD5 md5 = MD5.Create();
		bool CrackmeValidate(string email,string password)
		{
			


			byte[] kas_algo_result = kaspersky_algo(password);
			byte[] login_md5 = md5.ComputeHash(Encoding.UTF8.GetBytes(email));
			byte[] xor_encryption_result = new byte[16];
			for (uint i = 0; i < 16; i++)
			{
				xor_encryption_result[i] = (byte)(kas_algo_result[i] ^ login_md5[i]);
			}


			for (int i = 0; i < 5; i++)
			{
				byte[] three_byte_hash = md5.ComputeHash(xor_encryption_result, i * 3, 3);
				byte[] current_hard_coded_hash = StringToByteArray(HardcodedHashes[i]);
				if (!three_byte_hash.SequenceEqual(current_hard_coded_hash))
				{
					return false;
				}
			}


			byte chunk1 = 0;
			byte chunk2 = 0;
			byte chunk3 = 0;
			byte chunk4 = 0;
			byte it = 0;
			byte it2 = 0;

			for (int i=0;i< login_md5.Length;i+=4)
			{
				chunk1 += login_md5[i];
				chunk2 += login_md5[i + 3];
				chunk3 = (byte)(login_md5[i + 1] + it);
				chunk4 = (byte)(login_md5[i + 2] + it2);
				it2 = chunk4;
				it = chunk3;

			}

			return chunk1 + chunk2 + chunk3 + chunk4 == kas_algo_result[15];

		}

		private void buttonValidateCredentials_Click(object sender, EventArgs e)
		{
			string email = textBoxEmail.Text;
			string pass = textBoxPass.Text;
			if (pass.Length < 32 || !Regex.IsMatch(pass, @"\A\b[0-9a-fA-F]+\b\Z"))
			{
				MessageBox.Show("пароль должен представлять из себя 32 символную hex-строку (0..9 , a..f , A..F каждый)");
				return;
			}
			MessageBox.Show(CrackmeValidate(email, pass) ? "Успех! Пароль подходит к мылу" : "Не успех :( Пароль не подходит к мылу");

		}

		void BrutePassword( )
		{
			List<byte> xorEncryptionResult = new List<byte>();
			int timestamp = 0;
			int totalHashCount = 0xffffff;
			for (int hackingHashIndex = 0; hackingHashIndex < 5; hackingHashIndex++)
			{
				byte[] hardcodedHashAsByteArray = StringToByteArray(HardcodedHashes[hackingHashIndex]);

				for (int checkingHashIndex = 0; checkingHashIndex < totalHashCount; checkingHashIndex++)
				{
					if (timestamp == 0 || Environment.TickCount - timestamp >= 500)
					{
						timestamp = Environment.TickCount;
						this.BeginInvoke((MethodInvoker)(() =>
						{
							labelCheckedHashes.Text = "Хешей проверено: " + checkingHashIndex.ToString() + " / " + totalHashCount.ToString();
							progressBar1.Value = (int)((float)checkingHashIndex / (float)totalHashCount * (float)100.0f);
						}));
					}
					byte[] threeBytesBuffer = BitConverter.GetBytes(checkingHashIndex);
					byte[] threeBytesBufferShort = threeBytesBuffer.Take(3).ToArray();
					byte[] current_hash = md5.ComputeHash(threeBytesBufferShort);

					if (current_hash.SequenceEqual(hardcodedHashAsByteArray))
					{
						xorEncryptionResult.AddRange(threeBytesBufferShort);
						break;
					}
				}
				this.BeginInvoke((MethodInvoker)(() =>
				{
					labelHackingHashNumber.Text = "Взламываю хеш #"+ hackingHashIndex;
					progressBar2.Value += 25;
				}));

			}
		}



		private async void buttonStartBrutePasss_Click(object sender, EventArgs e)
		{
			
			await Task.Factory.StartNew(
											 () => BrutePassword(),
											 TaskCreationOptions.LongRunning);
		}
	}
}
