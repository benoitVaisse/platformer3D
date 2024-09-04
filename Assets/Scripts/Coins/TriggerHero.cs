
using UnityEditor;
using UnityEngine;
namespace scripts.coins
{
    public class TriggerHero : MonoBehaviour, ITriggerHero
    {
        private const string PATH_EFFECT_COIN_PARTICUL = "Assets/Prefabs/Particules/CoinParticule.prefab";
        [SerializeField]
        private GameObject _coinParticule;

        
        private AudioSource _audioSource;
        private CoinAnim _coinAnim;

        private void Start()
        {
            _coinParticule = Resources.Load<GameObject>("CoinParticule");
            _audioSource = GetComponent<AudioSource>();
            _coinAnim = GetComponent<CoinAnim>();
        }
        public void Action(GameObject hero)
        {
            hero.GetComponent<PlayerControllerTrigger>().AddCoins(1);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _audioSource.Play();
            _coinAnim.rotation = new(0, 1080, 0);
            _coinAnim.up = new(0, 2, 0);
            if (_coinParticule != null)
            {
                GameObject coinParticuleInstantiate = Instantiate(_coinParticule, gameObject.transform.position, Quaternion.identity);
                Destroy(coinParticuleInstantiate, 0.5f);
            }
            Destroy(gameObject, 1f);
        }
    }

}
