using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
	private static TextWriter instance;
	private List<TextWriterSingle> textWriterSingleList;
	
	private void Awake(){
		instance = this;
		textWriterSingleList = new List<TextWriterSingle>();
	}
	
	public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter, bool removeWriterBeforeAdd, Action onComplete){
		if(removeWriterBeforeAdd){
			instance.RemoveWriter(uiText);
		}
		return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacter, onComplete);
	}
	
	private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter, Action onComplete){
		TextWriterSingle textWriterSingle = new TextWriterSingle(uiText,textToWrite,timePerCharacter, invisibleCharacter, onComplete);
		textWriterSingleList.Add(textWriterSingle);
		return textWriterSingle;
		/*this.uiText = uiText;
		this.textToWrite = textToWrite;
		this.timePerCharacter = timePerCharacter;
		this.invisibleCharacter = invisibleCharacter;
		characterIndex = 0;*/
	}
	
	public static void RemoveWriter_Static(Text uiText){
		instance.RemoveWriter(uiText);
	}
	
	private void RemoveWriter(Text uiText){
		for(int i = 0; i < textWriterSingleList.Count; i++){
			if(textWriterSingleList[i].GetUIText() == uiText){
				textWriterSingleList.RemoveAt(i);
				i--;
			}
		}
	}
	
	private void Update(){
		//Debug.Log(textWriterSingleList.Count);
		for(int i = 0; i < textWriterSingleList.Count; i++){
			bool destroyInstance = textWriterSingleList[i].Update();
			if(destroyInstance){
				textWriterSingleList.RemoveAt(i);
				i--;
			}
		}
		/*if (textWriterSingle != null){
			textWriterSingle.Update();
		}*/
	}
	
	public class TextWriterSingle{
		
		private Text uiText;
		private string textToWrite;
		private int characterIndex;
		private float timePerCharacter;
		private float timer;
		private bool invisibleCharacter;
		private Action onComplete;
		
		
		public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter, Action onComplete){
			this.uiText = uiText;
			this.textToWrite = textToWrite;
			this.timePerCharacter = timePerCharacter;
			this.invisibleCharacter = invisibleCharacter;
			this.onComplete = onComplete;
				characterIndex = 0;
		}
			
			
		public bool Update(){
				//if(uiText != null){
				timer -= Time.deltaTime;
				while(timer <= 0f){
					timer += timePerCharacter;
					characterIndex++;
					string text = textToWrite.Substring(0, characterIndex);
					if(invisibleCharacter){
						text += "<color=#00000000>" + textToWrite.Substring(characterIndex) +"</color>";
					}
					uiText.text = text;
						
					if (characterIndex >= textToWrite.Length){
						//uiText = null;
						if(onComplete != null)onComplete();
						return true;
					}
			}
			return false;
		}
		
		public Text GetUIText(){
			return uiText;
		}
		
		public bool IsActive(){
			return characterIndex < textToWrite.Length;
		}
		
		public void WriteAllAndDestroy(){
			uiText.text = textToWrite;
			characterIndex = textToWrite.Length;
			if(onComplete != null)onComplete();
			TextWriter.RemoveWriter_Static(uiText);
		}
		
	}
}
