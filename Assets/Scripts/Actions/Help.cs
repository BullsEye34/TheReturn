using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Actions/Help")]
public class Help : Action
{ 
    public override void RespondToInput(GameController controller, string noun){
        controller.currentText.text = "Type a verb followed by a noun. \n\nEg: \n\"Go North\"\n\nAllowed Verbs: \ngo, \texamine, \tget, \tGive, \tuse, \tinventory, \ttalkto, \tsay, \thelp";
    }

}
