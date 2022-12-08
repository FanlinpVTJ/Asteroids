using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject tempObject;
    [SerializeField] private Image tempImage;
    [SerializeField] TextMeshProUGUI restartText;

    public bool resetGame = false;
    float restartTextAlfaChannel = 0f;

    public IEnumerator SceneChangerCoroutine(int StartAlfaChannel, int SceneIndex = 0, bool restartBool=false) ///0 уйти в затемнение, 1 выйди из затемнения///
    {
        int alfaChanel= StartAlfaChannel;

        while (alfaChanel == 0)
        {
            resetGame = false;
            tempImage = tempObject.GetComponent<Image>();
            tempImage.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, tempImage.color.a + 3f * Time.fixedDeltaTime);
            if (tempImage.color.a >= 1)
            {
                alfaChanel = 1;
                SceneManager.LoadScene(SceneIndex);
                break;
            }
            if (restartBool)
            {
                restartTextAlfaChannel += 20 * Time.deltaTime;
                restartText.color = new Color(restartText.color.r, restartText.color.g, restartText.color.b, restartTextAlfaChannel);
            }
            yield return new WaitForSeconds(0.05f);
        }

        while (alfaChanel == 1)
        {
            tempImage = tempObject.GetComponent<Image>();
            tempImage.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, tempImage.color.a - 3f * Time.fixedDeltaTime);
            if (tempImage.color.a <= 0)
            {
                alfaChanel = 0;
                resetGame = true;
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
