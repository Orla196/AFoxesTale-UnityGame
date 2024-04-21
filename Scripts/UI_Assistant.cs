using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class UI_Assistant : MonoBehaviour
{
	//[SerializeField] private TextWriter textWriter;
    private Text messageText;
	private TextWriter.TextWriterSingle textWriterSingle;
	private AudioSource talkingAudioSource;
	
	private void Awake(){
		messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
		talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
		
		transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
			if(textWriterSingle != null && textWriterSingle.IsActive()){
				textWriterSingle.WriteAllAndDestroy();
			}else{
			string[] messageArray = new string[] {
				"Hello Fox, I am Olive the owl, I've just moved in next door.",
				"Are you heading into town? It's only 7 acorns for the bus! so cheap!",
			};
			string message = messageArray[Random.Range(0, messageArray.Length)];
			StartTalkingSound();
			textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .1f, true, true, StopTalkingSound);
			}
		};
	}
	
	private void StartTalkingSound(){
		talkingAudioSource.Play();
	}
	private void StopTalkingSound(){
		talkingAudioSource.Stop();
	}
	
	private void Start(){
		//messageText.text = "Hello World";
		//TextWriter.AddWriter_Static(messageText,"Hello Fox, I am Olive the owl, I've just moved in next door.", .1f, true);
	}
	
}
