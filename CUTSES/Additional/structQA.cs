using System;
using System.Collections.Generic;

namespace CUTSES
{
	public class structQA
	{
		public string question;
		public int answerCount;
		public List<string> answer;
		public structQA ()
		{
			answer = new List<string>();
		}
		public structQA listToStruct(string question, string answerFirst, string answerSecond, string answerThird, string answerFourth)
		{
			this.question = question;
			answer [0] = answerFirst;
			answer [1] = answerSecond;
			answer [2] = answerThird;
			answer [3] = answerFourth;
			return this;
		}
		public structQA	templateStruct (int questionNumber, int answerCount )
		{
			this.answerCount = answerCount;
			this.question = "Question #" + questionNumber.ToString();
			for (int counter = 0; counter < answerCount; counter++) {
				this.answer.Add("Answer #" + (questionNumber * 100 + counter).ToString());
			}
			return this;
		}
	}
}

