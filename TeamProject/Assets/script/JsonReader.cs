using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class JsonReader : MonoBehaviour
{
    [System.Serializable]
	public class SubjectList
	{
		public Subject[] Subjects;
	}

    [System.Serializable]
	public class Subject
	{
		public string Name;
        public string FullName;
		public Question[] Questions;
	}

    [System.Serializable]
	public class Question
	{
		public string question;
		public string[] options;
		public string answer;
	}

	public static Subject GetData(string subject)
	{
		string json = System.IO.File.ReadAllText(@"../TeamProject/Assets/JSON/questionsLevel1.json");
		var list = new SubjectList();
		list = JsonUtility.FromJson<SubjectList>(json);
		
		foreach (var subj in list.Subjects)
		{
			if (subj.Name == subject)
			{
				return subj;
			}
		}

		return null;
	}
}
