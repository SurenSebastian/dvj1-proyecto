using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{

	public enum WorldObject 
	{
		LobiTheWolf,
		Wood,
		Stone,
		BackArrow,
		FrontArrow,
	}
	public enum WorldScenes
	{
		UncleWolfHouseScene,
		ForestScene,
	}

	public enum Direction
    {
		back,
		next,
    }

	public LobiTheWolf lobi;

    public void Start()
    {
		lobi = GameObject.FindGameObjectWithTag("Lobi").GetComponent<LobiTheWolf>();
    }

    public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f))
            {
				if (hit.transform != null)
                {
					WorldObjectDecider(hit.transform.gameObject);
				}
			}
		}
	}

	public void WorldObjectDecider(GameObject go)
    {
		Scene scene = SceneManager.GetActiveScene();
		if (go.name == WorldObject.LobiTheWolf.ToString())
        {
			print("HI THERE IM LOBI");
        } else if (go.name == WorldObject.BackArrow.ToString())
        {
			lobi.WalkToPositionAndLoadScene(go, GetNextSceneName(Direction.back, scene.name));
		}
		else if (go.name == WorldObject.FrontArrow.ToString())
		{
			lobi.WalkToPositionAndLoadScene(go, GetNextSceneName(Direction.next, scene.name));
		}
		else
        {
			lobi.WalkToPositionAndDestroy(go);
		}
	}

	public string GetNextSceneName(Direction direction, string currentScene)
    {
		if(currentScene == WorldScenes.ForestScene.ToString())
        {
			if(direction == Direction.back)
            {
				return WorldScenes.UncleWolfHouseScene.ToString();
			}
        }
		if (currentScene == WorldScenes.UncleWolfHouseScene.ToString())
		{
			if (direction == Direction.next)
			{
				return WorldScenes.ForestScene.ToString();
			}
		}
		return null;
	}
}
