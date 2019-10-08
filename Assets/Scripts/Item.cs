using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string description;
    public bool playerCanTake;
    public bool itemEnabled;
    public bool playerCanRead;
    public Interaction[] interactions;
    public Item targetItem = null;
    public bool PlayerCanTalkTo = false;
    public bool PlayerCanGiveTo = false;

    public bool InteractWith( GameController controller,string actionKeyword, string noun = ""){
        foreach(Interaction interaction in interactions){
            if(interaction.action.keyword.ToLower() == actionKeyword.ToLower()){
                if(noun.ToLower()!= "" && noun.ToLower()!=interaction.textToMatch.ToLower()){
                    continue;
                }
                
                foreach(Item disableItem in interaction.itemsToDisable){
                    disableItem.itemEnabled =false;
                }
                foreach(Item enableItem in interaction.itemsToEnable){
                    enableItem.itemEnabled =true;
                }
                foreach(Connection disableConnection in interaction.connectionsToDisable){
                    disableConnection.connectionEnabled =false;
                }
                foreach(Connection enableConnection in interaction.connectionsToEnable){
                    enableConnection.connectionEnabled =true;
                }
                
                if( interaction.teleportLocation != null){
                    controller.player.Teleport(controller, interaction.teleportLocation);
                }
                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
