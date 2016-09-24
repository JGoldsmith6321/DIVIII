using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cash : MonoBehaviour {

	public GameObject textObj;
	public GameObject buildingA;
	public GameObject buildingB;
	public GameObject buildingC;
	public GameObject buildingD;
	public GameObject buildingE;
	public GameObject buildingF;
	public GameObject buildingG;
	public GameObject buildingH;
	public GameObject buildingI;
	public GameObject buildingJ;
	public double cashNow;
	public double cashThisSession;
	public double cashThisSec;
	public float timeStart;
	public float timeNext;
	public float timeNow;//testing

	// Use this for initialization
	void Start () {
		cashNow = 0;
		timeStart = 0;
		timeNext = timeStart + 1;
	}

	public void UpdateMoneyText (){
			textObj.GetComponent<Text> ().text = "$" + cashNow;
	}

	public void ItemBought(double cost, double amount){
		cashNow = cashNow - (cost * amount);
		UpdateMoneyText ();
	}

	// Update is called once per frame
	void Update () {
		timeNow = Time.time;
	if (Time.time >= timeNext) {
		cashThisSec = buildingA.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingB.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingC.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingD.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingE.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingF.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingG.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingH.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingI.GetComponent<Buildings> ().buildingA.CashPerSecNow
			+ buildingJ.GetComponent<Buildings> ().buildingA.CashPerSecNow;
		cashNow = cashNow + cashThisSec;
		cashThisSession = cashThisSession + cashThisSec;
		timeNext = timeNext + 1;
	}
		UpdateMoneyText ();
	
	}
}
