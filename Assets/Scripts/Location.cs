using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public string locationText;
    [TextArea]
    public string description;
    public Connection[] connections;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string GetItemsText(){
        if(items.Count==0){
            return "";
        }
        string result = "You see ";
        bool first = true;
        foreach(Item item in items){
            if(item.itemEnabled){
                if(!first) result+=" and ";
                result += item.description;
                first = false;
            }
            

        }
        result+="\n";
        return result;
    }

    public string getConnectionsText(){
        string result = "";
        foreach(Connection connection in connections){
            if(connection.connectionEnabled){
                result+= connection.description + "\n";
            }

        }
        return result;
    }
     public bool HasItem(Item itemToCheck, GameController controller){
        foreach(Item item in items){
            if(item == itemToCheck && item.itemEnabled){
                return true;
            }
        }
        return false;
    }

    public Connection getConnection(string connectionNoun){
        foreach(Connection connection in connections){
            if(connection.connectionName.ToLower()==connectionNoun.ToLower()){
                return connection;
            }

        }
        return null;

    }
   
}
