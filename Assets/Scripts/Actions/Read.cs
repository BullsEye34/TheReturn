using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Actions/Read")]
public class Read : Action
{
   /*  public override void RespondToInput(GameController controller, string noun){
        foreach(Item item in controller.player.currentLocation.items){
            if(item.itemEnabled ){
                if(item.playerCanRead){
                    controller.currentText.text = item.Content;
                    return;
                }
            }
        }
        controller.currentText.text = "You can't Read that";
        
    }*/

    
    public override void RespondToInput(GameController controller, string noun){
        if(ReadItem(controller, controller.player.currentLocation.items,noun))
        return;

        if(ReadItem(controller, controller.player.inventory,noun))
        return;

        controller.currentText.text = "There is no "+noun;
    }
    private bool ReadItem(GameController controller, List<Item> items, string noun){
        foreach(Item item in items){
            if(item.itemName.ToLower() == noun.ToLower()){
                if(controller.player.CanReadItem(controller,item)){
                    if( item.InteractWith( controller,"read")) 
                        return true;
                    }
                    controller.currentText.text = "You have nothing on the " + noun + " that you can read";
                    return true;
                }
            }
        return false;
    }
}
