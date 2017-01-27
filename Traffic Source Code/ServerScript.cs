using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class ServerScript : MonoBehaviour {

	public Text t1;
	public Text t2;
	public Text t3;
	public Text t4;
	public Text t5;
	public Text t6;

	public InputField textbox;

	bool isServer;
	bool isClient;
	string nme;

	NetworkClient client;


	public class MyMsgType {
		public static short text = MsgType.Highest + 1;
	};


	public void move_text(){
		t1.text = t2.text;
		t2.text = t3.text;
		t3.text = t4.text;
		t4.text = t5.text;
		t5.text = t6.text;
		t6.text = textbox.text;
		textbox.text = "";
	}
	

	public void StartServer(){
		NetworkServer.Listen (7777);
		nme = "Server : ";

		//NetworkServer.RegisterHandler(MyMsgType.text,OnMessageRecieved);
	}

	public void StartClient (){
		client = new NetworkClient ();
		client.Connect (nme, 7777);
		nme = "Client : ";
	}

	//Server Functions

	public void Connect(string nickname){

	}

	public void Disconnect(int id){

	}

	public void Send_Msg(int id){
		StringMessage msg = new StringMessage(textbox.text);
		NetworkServer.SendToClient (id, MyMsgType.text, msg);
	}


	//Client Functions
	public void SendMsg(){
		StringMessage sended = new StringMessage (textbox.text);
		client.Send (MyMsgType.text, sended);
	}

	public void RecieveMsg(StringMessage msg){
		string new_message = msg.value;
		t1.text = t2.text;
		t2.text = t3.text;
		t3.text = t4.text;
		t4.text = t5.text;
		t5.text = t6.text;
		t6.text = new_message;
	}

}
