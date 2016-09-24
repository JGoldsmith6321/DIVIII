using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public struct Building{//the actual data of the buildings,
	public string Name; 
	public double CashPerSecOnStart;
	public double CashPerSecMultiplyer;
	public double CashPerSecNow; //start == (CaskPerSecStart*CashPerSecMultiplyer)*NumberOf
	public double CostAtStart;
	public double CostIncrement;
	public double CostNow; //start == (CostAtStart*NumberOf)+(CostAtStart*NumberOf)*CostIncrement
	public int NumberOf; //start == 0
	public Building(string name, double cashPerSecOnStart, double cashPerSecMultiplyer, double costAtStart, double costIncrement) {
		Name = name;
		CashPerSecOnStart = cashPerSecOnStart;
		CashPerSecMultiplyer = cashPerSecMultiplyer;
		CostAtStart = costAtStart;
		CostIncrement = costIncrement;
		NumberOf = 0;
		CashPerSecNow = (CashPerSecOnStart * CashPerSecMultiplyer) * NumberOf;
		CostNow = ((CostAtStart * NumberOf) + (CostAtStart * NumberOf) * CostIncrement)+CostAtStart;
	}
	public void AddBuildings(int numberToAdd){
		NumberOf = NumberOf + numberToAdd;
		CashPerSecNow = (CashPerSecOnStart * CashPerSecMultiplyer) * NumberOf;
		CostNow = ((CostAtStart * NumberOf) + (CostAtStart * NumberOf) * CostIncrement)+CostAtStart;
	}
} 

public class Buildings : MonoBehaviour {//mostly button behavior

	public string thisName;
	public int startNumOf; // A always starts with 1
	public double cashPerSecOnStart;
	public double cashPerSecMultiplyer;
	public double costAtStart;
	public double costIncrement;
	public Building buildingA;
	public int numberOf;
	public string txt;
	public double costNow;
	public GameObject thisButton;
	public GameObject cashCodeObj;


	void Start () {
		buildingA = new Building (thisName,cashPerSecOnStart,cashPerSecMultiplyer,costAtStart,costIncrement);
		buildingA.AddBuildings (startNumOf);
		UpdateButton();
	}
	
	void UpdateButton (){//just Button visuals
		numberOf = buildingA.NumberOf;
		costNow = buildingA.CostNow;
		txt = thisName + " Have: "+ numberOf + " Buy 1 at: $" + costNow;
		thisButton.GetComponentInChildren<Text> ().text = txt;
	}

	public void AddBuilding(){//when you click on a button, it buys 1
		if (cashCodeObj.GetComponentInChildren<Cash> ().cashNow >= costNow) {
			buildingA.AddBuildings (1);
			cashCodeObj.GetComponentInChildren<Cash> ().ItemBought (costNow, 1);
			UpdateButton ();
		}

	}

	void Update () {
	}
}
