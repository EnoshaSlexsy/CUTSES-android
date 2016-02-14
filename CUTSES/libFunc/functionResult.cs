using System;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;

namespace CUTSES
{
	public class functionResult
	{
		List<structQA> mainQA;
		List<int> userAnswer;
		List<string> answer = new List<string>();
		public functionResult ( List<structQA> inputQA, List<int> inputAnswer, TextView labelAnswer )
		{
			mainQA = inputQA;
			userAnswer = inputAnswer;
			for (int answerCurrent = 0; answerCurrent < userAnswer.Count; answerCurrent++) {
				if (userAnswer [answerCurrent] == -1) {
					answer.Add ((answerCurrent + 1).ToString () + ". ");
				} else {
					answer.Add ((answerCurrent + 1).ToString () + ". " + mainQA [answerCurrent].answer [userAnswer [answerCurrent]]);
				} 
			}
			listAnswerUpdate (labelAnswer);
		}
		public void listAnswerUpdate ( TextView labelAnswer )
		{
			for (int answerCurrent = 0; answerCurrent < answer.Count; answerCurrent++) {
				labelAnswer.Text += "\n" + answer [answerCurrent];
			}
		}

	}
}

