using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Colyseus;
using UnityEngine;

public static class Message
{
    public const string Server = "server-message";
    public const string Game = "game-message";
}

public static class GameMessage
{
    public const string Draw = "draw";
    public const string Drop = "drop";
}

/*public class MessageType
{
    public string value;

    public MessageType(string value)
    {
        this.value = value;
    }
}*/

public class NetworkManager : MonoBehaviour
{
    private static ColyseusClient client = null;
    private static ColyseusRoom<GameState> room = null;
    
    private GameManager GameManagerInst => GameManager.instance;
    
    public void Init()
    {
        ColyseusClient client = new ColyseusClient("ws://localhost:2567");
    }
    
    // Start is called before the first frame update
    async void Start()
    {
        Init();
        await JoinOrCreateGame();

        
        room.OnMessage<string>(Message.Server, message =>
        {
            Debug.Log("Server message: " + message);
        });
        
        room.OnMessage<string>(Message.Game, message =>
        {
            switch (message)
            {
                case GameMessage.Draw:
                    Debug.Log("draw");
                    GameManagerInst.DrawOpponent();
                    break;
                case GameMessage.Drop:
                    Debug.Log("drop");
                    GameManagerInst.Drop();
                    break;
            }
        });
        
    }

    public async Task JoinOrCreateGame()
    {
        room = await client.JoinOrCreate<GameState>("game");
    }

    public void SendMessage(string type)
    {
        room.Send("game-message", type);
    }

}
