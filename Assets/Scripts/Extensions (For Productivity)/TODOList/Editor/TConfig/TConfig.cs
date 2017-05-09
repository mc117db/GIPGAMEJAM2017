using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TConfig  {


	private static List<TagTemplate> _tags = new List<TagTemplate>();


	public static void initTags() {
		AddTag ("TODO", "#TODO");
		AddTag ("FIX",  "#FIX ME");
		AddTag ("TEST",  "#MY Tag");
		AddTag ("UNTESTED", "#UNTESTED");
	}



	public static List<TagTemplate> tags {
		get {
			return _tags;
		}
	}


	private static void AddTag(string patern, string name) {
		TagTemplate tpl = new TagTemplate (patern, name);
		_tags.Add (tpl);
	}
	
	
}
