using UnityEditor;
using UnityEngine;

public class TouchedByHero : MonoBehaviour, ITouchedByHero
{
    private const string PATH_EFFECT_COIN_PARTICUL = "Assets/Prefabs/Particules/SnailParticule.prefab";
    [SerializeField]
    private GameObject _snailParticule;

    private void Start()
    {
        _snailParticule = Resources.Load<GameObject>("SnailParticule");
    }
    public void Action()
    {
        iTween.ScaleTo(gameObject.transform.parent.gameObject, iTween.Hash(
            "scale", new Vector3(125f, 70f, 4.5f),
            "time", .02f,
            "easetype", iTween.EaseType.easeInElastic,
            "looptype", iTween.LoopType.none
        ));
        if (_snailParticule != null)
        {
            GameObject coinParticuleInstantiate = Instantiate(_snailParticule, gameObject.transform.position, Quaternion.identity);
            Destroy(coinParticuleInstantiate, 0.5f);
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject.transform.parent.gameObject, 0.75f);
    }
}
