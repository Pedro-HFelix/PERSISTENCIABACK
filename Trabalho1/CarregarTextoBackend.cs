using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CarregarTextoBackend : MonoBehaviour
{
    public InputField inputFieldURL;    //campo para inserir a URL
    public Button botaoProx;    //botão para mudar de página
    public Text txt_show;   //campo de texto para exibir
    public Image img_show;  //campo da imagem para exibir
    public int pag_atual = 1; //página atual da história
    void Start()
    {
        //carregar a URL padrão do repositório
        inputFieldURL.text = "https://github.com/Pedro-HFelix/PERSISTENCIABACK/blob/main/Trabalho1";

        //carregar por padrão a primeira página
        StartCoroutine(CarregarTxt());
        
        //botao para a próxima página
        botaoProx.onClick.AddListener(() => StartCoroutine(CarregarTxt()));
    }

    IEnumerator CarregarTxt()
    {
        //obter url base do repositório
        string url_req = inputFieldURL.text;

        //verifica se possui texto
        if (string.IsNullOrEmpty(url_req))
        {
            txt_show.text = "URL inválida!";
            yield break;
        }

        txt_show.text = "Carregando...";

        switch (pag_atual)
        {
            case 1:
                //atualizar url do InputField para pegar o texto1
                url_req = inputFieldURL.text + "/texto1.txt?raw=true";
                break;

            case 2:
                //atualizar url do InputField para pegar o texto2
                url_req = inputFieldURL.text + "/texto2.txt?raw=true";
                break;

            case 3:
                //atualizar url do InputField para pegar o texto3
                url_req = inputFieldURL.text + "/texto3.txt?raw=true";
                break;

            default:
                break;
        }


        print("Página atual -> " + pag_atual);

        print("Fazendo requisição da imagem na URL -> " + url_req);
        //faz a requisição
        UnityWebRequest request = UnityWebRequest.Get(url_req);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            StartCoroutine(LoadImage());
            txt_show.text = request.downloadHandler.text; //atualizar com o texto recebido   
        }
    }

    IEnumerator LoadImage()
    {
        //atualizar url para pegar uma imagem
        string url_req = null;

        switch (pag_atual)
        {
            case 1:
                //atualizar url do InputField para pegar a imagem1
                url_req = inputFieldURL.text + "/image1.png?raw=true";
                break;

            case 2:
                //atualizar url do InputField para pegar a imagem2
                url_req = inputFieldURL.text + "/image2.png?raw=true";
                break;

            case 3:
                //atualizar url do InputField para pegar a imagem3
                url_req = inputFieldURL.text + "/image3.png?raw=true";
                break;

            default:
                break;
        }

        print("Fazendo requisição da imagem na URL -> " + url_req);
        //faz a requisição
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url_req);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Rect rect = new Rect(0, 0, tex.width, tex.height);
            Vector2 center = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(tex, rect, center);
            img_show.sprite = sprite;
        }

        //atualizar página atual
        if (pag_atual < 3)
            pag_atual++;
        else
            pag_atual = 1; //loop de 1 -> 2 -> 3 -> 1...
    }
}