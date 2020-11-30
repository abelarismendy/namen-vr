using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject panelInfo; 
    public Button btn; 
    public void ChangeScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void SalirAlMenu(){
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void OpenInfoPanel ()
    {
        panelInfo.SetActive(true);
    }

    public void  CloseInfoPanel ()
    {
        panelInfo.SetActive(false);
    }
}
