using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class BossHP : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Explosion!
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            SoundEffectsHelper.Instance.MakeExplosionSound();
            // Dead!
            Destroy(gameObject);
            //敵倒した時の特殊効果表示
            //追加シーン
            //SceneManager.LoadScene("clear", LoadSceneMode.Additive);
            SceneManager.LoadScene("clear");
            // シーン遷移コルーチン開始
            //StartCoroutine(GoToTitleSceneCoroutine());
            
        }


       
    }

    IEnumerator GoToTitleSceneCoroutine()
    {

        // 5秒間待つ
        yield return new WaitForSeconds(5f);
        // TitleSceneに遷移
        SceneManager.LoadScene("clear");
        Debug.Log("clear");
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script

                
            }
        }
    }
}