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


		byte[] ReverseAlgoOptimized(byte[] data)
		{
			if (data.Length != 16)
				return null;
			for (int i = 0; i < data.Length; i += 4)
				Array.Reverse(data, i, 4);
			return data;
		}

		byte[] ReverseAlgo(string pass)
		{
			byte[] passAsHexBytes = StringToByteArray(pass.Substring(0, 32));
			uint block1 = BitConverter.ToUInt32(passAsHexBytes, 0);
			uint block2 = BitConverter.ToUInt32(passAsHexBytes, 4);
			uint block3 = BitConverter.ToUInt32(passAsHexBytes, 8);
			uint block4 = BitConverter.ToUInt32(passAsHexBytes, 12);


			uint v5 = block1 & 0xFF0000;     // //algo start for pass
			uint v6 = (((block1 >> 16) | v5) >> 8);
			uint v7 = block1 << 16;
			byte[] block1_byte_array = BitConverter.GetBytes(((block1 & 0xFF00 | v7) << 8) | v6) ;// 1 block assigned

			uint v8 = block2 & 0xFF0000;
			uint v9 = ((block2 >> 16) | v8) >> 8;
			uint v10 = block2 << 16;
			byte[] block2_byte_array = BitConverter.GetBytes(((block2 & 0xFF00 | v10) << 8) | v9);// 2 block assigned
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

		public static string ByteArrayToString(byte[] arr)
		{
			string result = "";
			foreach(byte b in arr)
			{
				result += b.ToString("X2");
			}
			return result;
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
			byte[] passAsByteArray = StringToByteArray(password);
			byte[] emailMd5 = md5.ComputeHash(Encoding.UTF8.GetBytes(email));
			byte[] controlHash = new byte[16];
			for (uint i = 0; i < 16; i+=4)
			{
				controlHash[i] = (byte)(passAsByteArray[i] ^ emailMd5[i]);
				controlHash[i + 1] = (byte)(passAsByteArray[i + 1] ^ emailMd5[i + 1]);
				controlHash[i + 2] = (byte)(passAsByteArray[i + 2] ^ emailMd5[i + 2]);
				controlHash[i + 3] = (byte)(passAsByteArray[i + 3] ^ emailMd5[i + 3]);
			}

			for (int i = 0; i < 5; i++)
			{
				byte[] buffer = md5.ComputeHash(buffer: controlHash, offset: i * 3, count:3);
				byte[] currentHardcodedHash = StringToByteArray(HardcodedHashes[i]);
				if (!buffer.SequenceEqual(currentHardcodedHash))
				{
					return false;
				}
			}

			byte chunk1 = 0;
			byte chunk2 = 0;
			byte chunk3 = 0;
			byte chunk4 = 0;

			for (int i=0;i< emailMd5.Length;i+=4)
			{
				chunk1 += emailMd5[i];
				chunk2 += emailMd5[i + 3];
				chunk3 += emailMd5[i + 1];
				chunk4 += emailMd5[i + 2];
			}

			return (byte)(chunk1 + chunk2 + chunk3 + chunk4) == controlHash[15];

		}

		private void buttonValidateCredentials_Click(object sender, EventArgs e)
		{
			string email = textBoxEmail.Text;
			string pass = textBoxPass.Text;
			if (string.IsNullOrEmpty(email))
			{
				MessageBox.Show("Заполните эмайл.");
			}
			if (pass.Length < 32 || !Regex.IsMatch(pass, @"\A\b[0-9a-fA-F]+\b\Z"))
			{
				MessageBox.Show("пароль должен представлять из себя 32 символную hex-строку (0..9 , a..f , A..F каждый)");
				return;
			}
			MessageBox.Show(CrackmeValidate(email, pass) ? "Успех! Пароль подходит к мылу" : "Не успех :( Пароль не подходит к мылу");

		}

		List<byte> GlobalControlHash = null;


		List<byte> BruteControlHash()
		{
			List<byte> controlHash = new List<byte>();

			int timestamp = 0;
			int totalHashCount = 0xffffff;
			int controlHashNeededLen = 15;
			for (int hackingHashIndex = 0; hackingHashIndex < HardcodedHashes.Length; hackingHashIndex++)
			{
				this.BeginInvoke((MethodInvoker)(() =>
				{
					labelHackingHashNumber.Text = "Взламываю хеш #" + (hackingHashIndex + 1) + " / " + HardcodedHashes.Length + "...";
				}));

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
					byte[] checkingHashIndexAsByteArray = BitConverter.GetBytes(checkingHashIndex).Take(3).ToArray();
					byte[] checkingHashIndexMd5 = md5.ComputeHash(checkingHashIndexAsByteArray);

					if (checkingHashIndexMd5.SequenceEqual(hardcodedHashAsByteArray))
					{
						controlHash.AddRange(checkingHashIndexAsByteArray);

						this.BeginInvoke((MethodInvoker)(() =>
						{

							labelControlHash.Text = "Контрольный хеш: ";

							for (int i = 0; i < controlHash.Count; i++)
							{
								labelControlHash.Text += controlHash[i].ToString("X");
							}

							for (int i = 0; i < controlHashNeededLen - controlHash.Count; i++)
							{
								labelControlHash.Text += "??";
							}

							progressBar2.PerformStep();
						}));
						break;
					}
				}
			}
			this.BeginInvoke((MethodInvoker)(() =>
			{
				progressBar1.Value = progressBar1.Maximum;
				progressBar2.Value = progressBar2.Maximum;
			}));
			return controlHash;
		}

		void RestorePassword(string email, List<byte> controlHash)
		{
			

			byte[] password = new byte[16];
			byte[] emailMd5 = md5.ComputeHash(Encoding.UTF8.GetBytes(email));

			for (int i = 0; i < 15; i++)
			{
				password[i] = (byte)(controlHash[i] ^ emailMd5[i]);
			}

			byte chunk1 = 0;
			byte chunk2 = 0;
			byte chunk3 = 0;
			byte chunk4 = 0;
			for (int i = 0; i < emailMd5.Length; i += 4)
			{
				chunk1 += emailMd5[i];
				chunk2 += emailMd5[i + 3];
				chunk3 += emailMd5[i + 1];
				chunk4 += emailMd5[i + 2];
			}
			password[15] = (byte)(chunk1 + chunk2 + chunk3 + chunk4);
			password[15] ^= emailMd5[15];

			textBoxPass.Text = ByteArrayToString(password);
			MessageBox.Show("Пароль восстановлен и помещен в текстовое поля для пароля.","Успех",MessageBoxButtons.OK, MessageBoxIcon.Information);


		}



		private void Form1_Load(object sender, EventArgs e)
		{
			string setting = Properties.Settings.Default["CrackMeControlHash"].ToString();
			if (string.IsNullOrEmpty(setting))
				return;

			GlobalControlHash = new List<byte>( Convert.FromBase64String(setting));
			buttonRestorePassword.Enabled = true;
			buttonValidateCredentials.Enabled = true;
			labelControlHash.Text = "Контрольный хеш: " + ByteArrayToString(GlobalControlHash.ToArray());
			labelInfo.Text = "Контрольный хеш восстановлен с диска.";
		}


		void SaveControlHash(List<byte> controlHash)
		{
			
			Properties.Settings.Default["CrackMeControlHash"] = Convert.ToBase64String(controlHash.ToArray());
			Properties.Settings.Default.Save();
		}

		private async void buttonBruteControlHash_Click(object sender, EventArgs e)
		{

				//GlobalControlHash = BruteControlHash();
				//this.BeginInvoke((MethodInvoker)(() =>
				//{

					
				//}));


			GlobalControlHash = await Task.Factory.StartNew(BruteControlHash,TaskCreationOptions.LongRunning);

			buttonRestorePassword.Enabled = true;
			buttonValidateCredentials.Enabled = true;
			DialogResult result = MessageBox.Show("Контрольный хеш сбручен. Теперь можно восстановить пароль, а так же проверить его аутентичность по алгоритму CrackMe! Сохранить контрольный хеш на диск, что бы в будущем программа сама подгружала его?", "Успех", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (result == DialogResult.Yes)
				SaveControlHash(GlobalControlHash);
		}

		private void buttonRestorePassword_Click(object sender, EventArgs e)
		{
			string email = textBoxEmail.Text;
			  RestorePassword(email,GlobalControlHash);
		}
	}
}
