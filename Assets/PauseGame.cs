using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System;



public class PauseGame : MonoBehaviour
{
    //public Sprite blue;
    int CatActive;
    float timeCurrent1;
    float timeCurrent2;

    static int money;
    static int cash;
    bool num;
    int num1;
    int num2;
    bool num3;
    int n = 0;
    bool Exitnum;
    int Exitnum2;
    int settingbutton;

    // ------------shop---------------//
    static int applenum;
    static int banananum;
    static int lemonnum;
    static int orangenum;
    static int pearnum;
    static int strawberrynum;
    static int cardsnum;
    static int controllernum;
    static int bishopnum;
    static int tennisnum;
    static int runningnum;
    static int floatingnum;
    //---------------------------------//

    static int Level;
    static int ID;
    int SumMusic;
    string OnMusic;
    string OffMusic;
    int SumSound;
    string OnSound;
    string OffSound;

    public PauseGame(string data)
    {
        var N = JSON.Parse(data);
        money = N["data"]["money"].AsInt;
        Level = N["data"]["lvl"].AsInt;
        ID = N["data"]["user_id"].AsInt;
        exp = N["data"]["exp"].AsInt;

        float currentTime = (float)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        float databaseTime = N["data"]["last_save"].AsFloat;

        float el = currentTime - databaseTime;

        if(N["data"]["hungry"].AsInt - (el/60) > 0) {
            hungry2 = (int)(N["data"]["hungry"].AsInt - (el/60));
        } else {
            hungry2 = 0;
        }

        if(N["data"]["clean"].AsInt - (el/60) > 0) {
            clean2 = (int)(N["data"]["clean"].AsInt - (el/60));
        } else {
            clean2 = 0;
        }

    }

    public void setItem(string data)
    {
        var N = JSON.Parse(data);
        
        // print(N["item"][1]["qty"] == null);
        for (int i = 0; i < N["item"].Count ; i++){
            for (int j = 0; j < 6 ; j++){

                switch (N["item"][j]["item_id"].AsInt) {
                    case 1 :
                        applenum = N["item"][j]["qty"].AsInt;
                        break;

                    case 2 :
                        banananum = N["item"][j]["qty"].AsInt;
                        break;

                    case 3 :
                        lemonnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 4 :
                        orangenum = N["item"][j]["qty"].AsInt;
                        break;

                    case 5 :
                        pearnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 6 :
                        strawberrynum = N["item"][j]["qty"].AsInt;
                        break;

                    case 7:
                        cardsnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 8:
                        controllernum = N["item"][j]["qty"].AsInt;
                        break;

                    case 9:
                        bishopnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 10:
                        tennisnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 11:
                        runningnum = N["item"][j]["qty"].AsInt;
                        break;

                    case 12:
                        floatingnum = N["item"][j]["qty"].AsInt;
                        break;
                }
            }
        }
    }


    public Transform settingView;
    public Transform bgView;
    public Transform btnBack;
    public Transform btnMoney1;
    public Transform btncash;
    public Transform btnSetting;
    public Transform btnEat;
    public Transform btnShower;
    public Transform btnItem;
    public Transform btnShow;
    public Transform chacktime;
    public Transform chacktime2;
    public Transform hungry1;
    public Transform clean1;
    public Transform Yes;
    public Transform No;
    public Transform Exit;
    public Transform Status;

    //ท่าทาง//
    float Idlefloat;
    float Jumpfloat;
   // private Animator move;
    public Transform Idle;
    public Transform Jump;
  //  public Transform Jump;
    //---------------//

    //หน้าจอแต่ละหน้า//
    public Transform main;
    public Transform Shop;
    public Transform Item;
    //---------------//

    //money//
    public Transform money1;
    public Transform money2;
    public Transform money3;
    public Transform money4;
    public Transform money5;
    public Transform money6;
    //------------------//

    public Transform Panel1;
    public Transform Panel2;
    public Transform Panel3;

    //------------shop------------//
    public Transform apple;
    public Transform banana;
    public Transform lemon;
    public Transform orange;
    public Transform pear;
    public Transform strawberry;
    public Transform cards;
    public Transform controller;
    public Transform bishop;
    public Transform tennis;
    public Transform running;
    public Transform floating;
    //---------------------------//

    public Transform Meal;
    public Transform Resume;
    public Transform sounds;
    public Transform SaveExit;
    public Transform Credits;
    public Transform CreditsBtn;
    public Transform CreditsText;
    public Transform PauseText;
    public Transform soundsText;
    public Transform back;
    public Transform Meal1;
    public Transform Meal2;
    public Transform Happy1;
    public Transform Happy2;

    //shop//
    public Transform appletext;
    public Transform bananatext;
    public Transform lemontext;
    public Transform orangetext;
    public Transform peartext;
    public Transform strawberrytext;
    public Transform cardstext;
    public Transform controllertext;
    public Transform bishoptext;
    public Transform tennistext;
    public Transform runningtext;
    public Transform floatingtext;
    //-----//

    public Transform Leveltext;


    //------------Sound---------//
    public Transform MusicText;
    public Transform SoundEffectsText;
    public Transform MusicBtn;
    public Transform SoundBtn;
    public Transform Music;
    public Transform Sound;
    public Transform MusicBtnText;
    public Transform SoundBtnText;
    //-----------------------------------//

    //--------ProgressBar-------//
    public Transform LoadingBar;
    public Transform TextIndicator;
    public Transform TextLoading;
   // [SerializeField] public int Level;
    [SerializeField] private float speed;
    [SerializeField] private static float exp;
    //--------------------------//

    //---------progress bar--------//
    static float hungry2;
    static float clean2;
    [SerializeField] private float speedFull;
    [SerializeField] private float speedClean;

    public Transform LoadingFullBar;
    public Transform LoadingCleanBar;
    //-----------------------------//

    public Transform Happy;

    public void settingSoundOnOff()
    {
        SumSound++;
            if(SumSound%2 == 1)
        {
            Sound.gameObject.SetActive(true);
            SoundBtnText.gameObject.GetComponent<Text>().text = OnSound.ToString();
        }
        else
        {
            Sound.gameObject.SetActive(true);
            SoundBtnText.gameObject.GetComponent<Text>().text = OffSound.ToString();
        }
    } 

    public void settingMusicOnOff()
    {
        SumMusic++;
            if(SumMusic%2 == 1)
        {
            Music.gameObject.SetActive(false);
            MusicBtnText.gameObject.GetComponent<Text>().text = OffMusic.ToString();
        }
        else
        {
            Music.gameObject.SetActive(true);
            MusicBtnText.gameObject.GetComponent<Text>().text = OnMusic.ToString();
        }
    }

    public void backsetting()
    {
        back.gameObject.SetActive(false);
        soundsText.gameObject.SetActive(false);
        MusicText.gameObject.SetActive(false);
        SoundEffectsText.gameObject.SetActive(false);
        MusicBtn.gameObject.SetActive(false);
        SoundBtn.gameObject.SetActive(false);

        Resume.gameObject.SetActive(true);
        sounds.gameObject.SetActive(true);
        SaveExit.gameObject.SetActive(true);
        PauseText.gameObject.SetActive(true);
        CreditsBtn.gameObject.SetActive(true);
    }

    public void Sounds()
    {
        back.gameObject.SetActive(true);
        soundsText.gameObject.SetActive(true);
        MusicText.gameObject.SetActive(true);
        //SoundEffectsText.gameObject.SetActive(true);
        MusicBtn.gameObject.SetActive(true);
       // SoundBtn.gameObject.SetActive(true);

        Resume.gameObject.SetActive(false);
        sounds.gameObject.SetActive(false);
        SaveExit.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        CreditsText.gameObject.SetActive(false);
        PauseText.gameObject.SetActive(false);
        CreditsBtn.gameObject.SetActive(false);
    }

    public void floatingbutton()
    {
        Debug.Log("chack");
        if (floatingnum > 0)
        {
            floatingnum -= 1;
            clean2 += 60;
            exp += speed + 60;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("12");
        }
        else
        {

        }
    }

    public void runningbutton()
    {
        Debug.Log("chack");
        if (runningnum > 0)
        {
            runningnum -= 1;
            clean2 += 50;
            exp += speed + 50;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("11");
        }
        else
        {

        }
    }

    public void tenninsbutton()
    {
        Debug.Log("chack");
        if (tennisnum > 0)
        {
            tennisnum -= 1;
            clean2 += 40;
            exp += speed + 40;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("10");
        }
        else
        {

        }
    }

    public void bishopbutton()
    {
        Debug.Log("chack");
        if (bishopnum > 0)
        {
            bishopnum -= 1;
            clean2 += 30;
            exp += speed + 30;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("9");
        }
        else
        {

        }
    }

    public void controllerbutton()
    {
        Debug.Log("chack");
        if (controllernum > 0)
        {
            controllernum -= 1;
            clean2 += 20;
            exp += speed + 20;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("8");
        }
        else
        {

        }
    }

    public void cardsbutton()
    {
        Debug.Log("chack");
        if (cardsnum > 0)
        {
            cardsnum -= 1;
            clean2 += 10;
            exp += speed + 10;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("7");
        }
        else
        {

        }
    }

    public void strawberrybutton()
    {
        Debug.Log("chack");
        if (strawberrynum > 0)
        {
            strawberrynum -= 1;
            hungry2 += 35;
            exp += speed + 35;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("6");
        }
        else
        {

        }
    }

    public void pearbutton()
    {
        Debug.Log("chack");
        if (pearnum > 0)
        {
            pearnum -= 1;
            hungry2 += 30;
            exp += speed + 30;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("5");
        }
        else
        {

        }
    }

    public void orangebutton()
    {
        Debug.Log("chack");
        if (orangenum > 0)
        {
            orangenum -= 1;
            hungry2 += 25;
            exp += speed + 25;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("4");
        }
        else
        {

        }
    }

    public void lemonbutton()
    {
        Debug.Log("chack");
        if (lemonnum > 0)
        {
            lemonnum -= 1;
            hungry2 += 20;
            exp += speed + 20;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("3");
        }
        else
        {

        }
    }

    public void bananabutton()
    {
        Debug.Log("chack");
        if (banananum > 0)
        {
            banananum -= 1;
            hungry2 += 15;
            exp += speed + 15;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("2");
        }
        else
        {

        }
    }

    public void applebutton()
    {
        Debug.Log("chack");
        if (applenum > 0)
        {
            applenum -= 1;
            hungry2 += 10;
            exp += speed + 10;
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(true);
            Idle.gameObject.SetActive(false);

            setEat("1");
        }
        else
        {
           
        }
    }

    public void setEat(string i){
        WWWForm form = new WWWForm(); 
        form.AddField("user_id", ID); 
        form.AddField("item_id", i);
        StartCoroutine(SaveBag(form));
    }

    IEnumerator SaveBag(WWWForm form)
    {        
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/eat.php", form);


        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("connection ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                setStatus();
            }
        }
        //Work with the retrieved info.

    }

    public void Left()
    {
        Meal1.gameObject.SetActive(true);
        Meal2.gameObject.SetActive(false);
        Happy1.gameObject.SetActive(true);
        Happy2.gameObject.SetActive(false);
    }

    public void Right()
    {
        Meal1.gameObject.SetActive(false);
        Meal2.gameObject.SetActive(true);
        Happy1.gameObject.SetActive(false);
        Happy2.gameObject.SetActive(true);
    }

    public void CreditsButton()
    {
        Credits.gameObject.SetActive(true);
        CreditsText.gameObject.SetActive(true);
        PauseText.gameObject.SetActive(false);
    }

    public void Happybutton()
    {
        num2++;

        if (num2 % 2 == 0)
        {
            num3 = true;
            //num1++;
           // Meal.gameObject.SetActive(false);
        }
        else
        {
            num3 = false;
        }

        //Meal.gameObject.SetActive(!num3);
        Happy.gameObject.SetActive(num3);
    }

    public void mealButton()
    {
        num1++;
        Debug.Log(num1);
        if(num1%2 == 0)
        {
            num = true;
           // num2++;
            //Happy.gameObject.SetActive(false);
        }
        else
        {
            num = false;
        }

       // Happy.gameObject.SetActive(!num);
        Meal.gameObject.SetActive(num);
    }

        public void Yesfloatin()
    {
        if (money > 0)
        {
            money -= 60;
            floatingnum += 1;

            setShop("12");
        }
        floating.gameObject.SetActive(false);
    }

    public void Nofloatin()
    {
        floating.gameObject.SetActive(false);
    }

    public void Floatin()
    {
        floating.gameObject.SetActive(true);
    }

    public void YesRunning()
    {
        if (money > 0)
        {
            money -= 50;
            runningnum += 1;

            setShop("11");
        }
        running.gameObject.SetActive(false);
    }

    public void NoRunning()
    {
        running.gameObject.SetActive(false);
    }

    public void Running()
    {
        running.gameObject.SetActive(true);
    }

    public void YesTennis()
    {
        if (money > 0)
        {
            money -= 40;
            tennisnum += 1;

            setShop("10");
        }
        tennis.gameObject.SetActive(false);
    }

    public void NoTennis()
    {
        tennis.gameObject.SetActive(false);
    }

    public void Tennis()
    {
        tennis.gameObject.SetActive(true);
    }

    public void YesBishop()
    {
        if (money > 0)
        {
            money -= 30;
            bishopnum += 1;

            setShop("9");
        }
        bishop.gameObject.SetActive(false);
    }

    public void NoBishop()
    {
        bishop.gameObject.SetActive(false);
    }

    public void Bishop()
    {
        bishop.gameObject.SetActive(true);
    }

    public void YesController()
    {
        if (money > 0)
        {
            money -= 20;
            controllernum += 1;

            setShop("8");
        }
        controller.gameObject.SetActive(false);
    }

    public void NoController()
    {
        controller.gameObject.SetActive(false);
    }

    public void Controller()
    {
       controller.gameObject.SetActive(true);
    }   

    public void YesCards()
    {
        if (money > 0)
        {
            money -= 10;
            cardsnum += 1;

            setShop("7");
        }
        cards.gameObject.SetActive(false);
    }

    public void NoCards()
    {
        cards.gameObject.SetActive(false);
    }

    public void Cards()
    {
        cards.gameObject.SetActive(true);
    }

    public void YesStrawberry()
    {
        if (money > 0)
        {
            money -= 35;
            strawberrynum += 1;
            
            setShop("6");
        }
        strawberry.gameObject.SetActive(false);
    }

    public void NoStrawberry()
    {
        strawberry.gameObject.SetActive(false);
    }

    public void Strawberry()
    {
        strawberry.gameObject.SetActive(true);
    }

    public void YesPear()
    {
        if (money > 0)
        {
            money -= 30;
            pearnum += 1;
            
            setShop("5");
        }
        pear.gameObject.SetActive(false);
    }

    public void NoPear()
    {
        pear.gameObject.SetActive(false);
    }

    public void Pear()
    {
        pear.gameObject.SetActive(true);
    }

    public void YesOrange()
    {
        if (money > 0)
        {
            money -= 25;
            orangenum += 1;
            
            setShop("4");
        }
        orange.gameObject.SetActive(false);
    }

    public void NoOrange()
    {
        orange.gameObject.SetActive(false);
    }

    public void Orange()
    {
        orange.gameObject.SetActive(true);
    }

    public void YesLemon()
    {
        if (money > 0)
        {
            money -= 20;
            lemonnum += 1;
            
            setShop("3");
        }
        lemon.gameObject.SetActive(false);
    }

    public void NoLemon()
    {
        lemon.gameObject.SetActive(false);
    }

    public void Lemon()
    {
        lemon.gameObject.SetActive(true);
    }

    public void YesBanana()
    {
        if (money > 0)
        {
            money -= 15;
            banananum += 1;

            setShop("2");
        }
        banana.gameObject.SetActive(false);
    }

    public void NoBanana()
    {
        banana.gameObject.SetActive(false);
    }

    public void Banana()
    {
        banana.gameObject.SetActive(true);
    }

    public void YesApple()
    {
        if (money > 0)
        {
            money -= 10;
            applenum += 1;

            setShop("1");
        }
        apple.gameObject.SetActive(false);
    }

    public void NoApple()
    {
        apple.gameObject.SetActive(false);
    }

    public void Apple()
    {
        apple.gameObject.SetActive(true);   
    }

    public void setShop(string i)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", ID);
        form.AddField("item_id", i);
        StartCoroutine(SaveItem(form));
    }

    IEnumerator SaveItem(WWWForm form)
    {
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/shop.php", form);


        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("connection ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                setStatus();
            }
        }
        //Work with the retrieved info.

    }

    public void left()
    {
        if(n > 0)
        {
            n = n-1;
            setPage(n);
        }
    }

    public void right()
    {
        if (n < 2)
        {
            n = n+1;
            setPage(n);
        }
    }

    public void setPage(int n)
    {
        switch (n)
        {
            case 0:
                Panel1.gameObject.SetActive(true);
                Panel2.gameObject.SetActive(false);
                Panel3.gameObject.SetActive(false);
                break;

            case 1:
                Panel1.gameObject.SetActive(false);
                Panel2.gameObject.SetActive(true);
                Panel3.gameObject.SetActive(false);
                break;

            case 2:
                Panel1.gameObject.SetActive(false);
                Panel2.gameObject.SetActive(false);
                Panel3.gameObject.SetActive(true);
                break;
        }
    }

    public void ClickYes()
    {
        Debug.Log("ClickYes");

        setStatusAndQuit();
    }

    IEnumerator SaveStatusQuit(WWWForm form)
    {        
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/save.php", form);


        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("connection ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                print("Save Status And Quit");
                Time.timeScale = 0;
                Application.Quit();
            }
        }
        //Work with the retrieved info.

    }

    public void ClickNo()
    {
        settingbutton++;
        Debug.Log("ClickNo");
        Idle.gameObject.SetActive(true);
        Status.gameObject.SetActive(true);
        Exit.gameObject.SetActive(false);   
        Time.timeScale = 1;
    }

    public void Exit1()
    {
        Debug.Log("Exit1");
        Exit.gameObject.SetActive(true);
        settingView.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickSetting()
    {
      settingbutton++;
        Exit.gameObject.SetActive(false);
        Debug.Log("ClickSetting");
        if(settingbutton%2 == 1)
        {
            settingView.gameObject.SetActive(true);
            bgView.gameObject.SetActive(true);
            Resume.gameObject.SetActive(true);
            sounds.gameObject.SetActive(true);
            SaveExit.gameObject.SetActive(true);
            PauseText.gameObject.SetActive(true);
            CreditsBtn.gameObject.SetActive(true);

            Status.gameObject.SetActive(false);
            Idle.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            soundsText.gameObject.SetActive(false);
            MusicText.gameObject.SetActive(false);
            SoundEffectsText.gameObject.SetActive(false);
            MusicBtn.gameObject.SetActive(false);
            SoundBtn.gameObject.SetActive(false);


            Time.timeScale = 0;
        }
        else
        {

            bgView.gameObject.SetActive(true);
            Status.gameObject.SetActive(true);
            Idle.gameObject.SetActive(true);
            PauseText.gameObject.SetActive(true);

            settingView.gameObject.SetActive(false);
            Credits.gameObject.SetActive(false);
            CreditsText.gameObject.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void ClickResume()
    {
        Debug.Log("ClickResume");
        settingbutton++;
        Status.gameObject.SetActive(true);
        Idle.gameObject.SetActive(true);
        settingView.gameObject.SetActive(false);
 
        Time.timeScale = 1;
    }
    public void ClickShop()
    {
        Debug.Log("ClickShop");
        Shop.gameObject.SetActive(true);
        Idle.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickItem()
    {
        Debug.Log("ClickItem");
        Item.gameObject.SetActive(true);
        Idle.gameObject.SetActive(false);
        main.gameObject.SetActive(false);   
        Time.timeScale = 0;
    }

    public void ClickBack()
    {
        Debug.Log("ClickBack");
        main.gameObject.SetActive(true);
        Idle.gameObject.SetActive(true);
        Shop.gameObject.SetActive(false);
        Item.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        Idlefloat += Time.deltaTime;
        Jumpfloat += Time.deltaTime;
        if (Jumpfloat >= 1)
        {
            Debug.Log("Jump");
            Jumpfloat = 0.0f;
            Jump.gameObject.SetActive(false);
            Idle.gameObject.SetActive(true);
        }

        timeCurrent1 += Time.deltaTime;
        timeCurrent2 += Time.deltaTime;
        money1.gameObject.GetComponent<Text>().text = money.ToString();
        money2.gameObject.GetComponent<Text>().text = cash.ToString();
        money3.gameObject.GetComponent<Text>().text = money.ToString();
        money4.gameObject.GetComponent<Text>().text = cash.ToString();
        money5.gameObject.GetComponent<Text>().text = money.ToString();
        money6.gameObject.GetComponent<Text>().text = cash.ToString();

        chacktime.gameObject.GetComponent<Text>().text = timeCurrent1.ToString();
        chacktime2.gameObject.GetComponent<Text>().text = timeCurrent2.ToString();

        //shop//
        appletext.gameObject.GetComponent<Text>().text = applenum.ToString();
        bananatext.gameObject.GetComponent<Text>().text = banananum.ToString();
        lemontext.gameObject.GetComponent<Text>().text = lemonnum.ToString();
        orangetext.gameObject.GetComponent<Text>().text = orangenum.ToString();
        peartext.gameObject.GetComponent<Text>().text = pearnum.ToString();
        strawberrytext.gameObject.GetComponent<Text>().text = strawberrynum.ToString();
        cardstext.gameObject.GetComponent<Text>().text = cardsnum.ToString();
        controllertext.gameObject.GetComponent<Text>().text = controllernum.ToString();
        bishoptext.gameObject.GetComponent<Text>().text = bishopnum.ToString();
        tennistext.gameObject.GetComponent<Text>().text = tennisnum.ToString();
        runningtext.gameObject.GetComponent<Text>().text = runningnum.ToString();
        floatingtext.gameObject.GetComponent<Text>().text = floatingnum.ToString();
    //--------//

    Leveltext.gameObject.GetComponent<Text>().text = Level.ToString();
        
        // Level//
        if( exp >= 100)
        {
            Level += 1;
            money += Level * 100;
            exp -= 100;
            TextIndicator.GetComponent<Text>().text = ((int)Level).ToString();
            TextLoading.gameObject.SetActive(true);
        }

        LoadingBar.GetComponent<Image>().fillAmount = exp/100; //ทำให้มันหมุนครบ 100%//
        //----------------------------------------//

        //
        LoadingFullBar.GetComponent<Image>().fillAmount = hungry2 / 100;
        LoadingCleanBar.GetComponent<Image>().fillAmount = clean2 / 100;
        //

        if (hungry2 >= 100)
        {
            hungry2 = speedFull + 100;
        }
        if(clean2 >= 100)
        {
            clean2 = speedClean + 100;
        }

        hungry1.gameObject.GetComponent<Text>().text = hungry2.ToString()+"%";
        clean1.gameObject.GetComponent<Text>().text = clean2.ToString()+"%";
        if (timeCurrent1 >= 5 && hungry2 > 0)
        {
            hungry2--;
            timeCurrent1 = 0.0f;

            setStatus();
        }
        if( timeCurrent2 >= 10 && clean2 > 0)
        {
            clean2--;
            timeCurrent2 = 0.0f;

            setStatus();
        }

       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exitnum2++;
            if (Exitnum2%2 == 0)
            {
                settingView.gameObject.SetActive(false);
                Idle.gameObject.SetActive(false);
                Status.gameObject.SetActive(false);
                Exitnum = true;
                Time.timeScale = 0;
            }
            else
            {
                Exitnum = false;
                Idle.gameObject.SetActive(true);
                Status.gameObject.SetActive(true);
                Time.timeScale = 1;
            }
        Exit.gameObject.SetActive(Exitnum);
        }
    }

    public void setStatus(){
        WWWForm form = new WWWForm(); 
        form.AddField("user_id", ID); 
        form.AddField("money", money);
        form.AddField("cash", cash);
        form.AddField("lvl", ((int)Level).ToString());
        form.AddField("exp", ((int)exp).ToString());
        form.AddField("hungry", ((int)hungry2).ToString());
        form.AddField("clean", ((int)clean2).ToString());
        StartCoroutine(SaveStatus(form));
    }

    public void setStatusAndQuit(){
        WWWForm form = new WWWForm(); 
        form.AddField("user_id", ID); 
        form.AddField("money", money);
        form.AddField("cash", cash);
        form.AddField("lvl", ((int)Level).ToString());
        form.AddField("exp", ((int)exp).ToString());
        form.AddField("hungry", ((int)hungry2).ToString());
        form.AddField("clean", ((int)clean2).ToString());
        StartCoroutine(SaveStatusQuit(form));
    }

    IEnumerator SaveStatus(WWWForm form)
    {        
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/save.php", form);


        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("connection ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                print("Save Status");
            }
        }
        //Work with the retrieved info.

    }

    void Start()
    {

        timeCurrent1 = 0.0f;
        timeCurrent2 = 0.0f;
        // hungry2 = 100;
        // clean2 = 100;
        // cash = 0;
        num = false;
        num1 = 1;
        num3 = false;
        num2 = 1;
        Exitnum = false;
        Exitnum2 = 1;
        settingbutton = 0;
        SumMusic = 0;
        OnMusic = "On";
        OffMusic = "Off";
        SumSound = 0;
        OnSound = "On";
        OffSound = "Off";

        setStatus();

        //lv//
        // exp = 0;
        //-------//
        // applenum = 20;
        //เก็บค่า Animation//
       // move = GetComponent<Animator>();
        //-------------------------//
    }
}

