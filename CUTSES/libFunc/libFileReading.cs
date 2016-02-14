using System;
using System.Collections.Generic;
using System.IO;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;

namespace CUTSES
{
	public class libFileReading
	{
		public libFileReading ()
		{
		}
		public List<structQA> fileLoad( string fileName)
		{
			string path =  System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			string file = Path.Combine(path, fileName);
			List<structQA> readingQA = new List<structQA>();
			using (StreamReader QA = new StreamReader(file)) {
				int testCount = Int32.Parse(QA.ReadLine());
				for (int currentTest = 0; currentTest < testCount; currentTest++) {
					readingQA.Add ((new structQA ()).listToStruct (
						QA.ReadLine (), QA.ReadLine (), QA.ReadLine (), QA.ReadLine (), QA.ReadLine ()));
				}
			}
			return readingQA;
		}
	}
}

