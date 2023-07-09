using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingManager : GenericSingleton<OnboardingManager>
{

    [SerializeField] GameObject OnboardingSceneOne;
    [SerializeField] GameObject OnboardingSceneTwo;
    [SerializeField] GameObject OnboardingSceneThree;
    [SerializeField] GameObject OnboardingSceneFour;
    [SerializeField] GameObject OnboardingSceneFive;
    [SerializeField] GameObject OnboardingSceneSix;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Progression.roundNumber == 0 && OnboardingSceneOne != null && !OnboardingSceneOne.activeSelf)
        {
            DisplayOnboardingOne();
        }
    }

    public void DisplayOnboardingOne(){ if (OnboardingSceneOne != null) OnboardingSceneOne.SetActive(true);}
    public void DisplayOnboardingTwo() { if(OnboardingSceneTwo != null) OnboardingSceneTwo.SetActive(true); }

    public void DisplayOnboardingThree() { if (OnboardingSceneThree != null) OnboardingSceneThree.SetActive(true);}
    public void DisplayOnboardingFour() { if (OnboardingSceneFour != null) OnboardingSceneFour.SetActive(true); }
    public void DisplayOnboardingFive() { if (OnboardingSceneFive != null) OnboardingSceneFive.SetActive(true); }
    public void DisplayOnboardingSix() { if (OnboardingSceneSix != null) OnboardingSceneSix.SetActive(true); }



    public void DestroyOnboardingOne(){ if(OnboardingSceneOne != null) Destroy(OnboardingSceneOne);}
    public void DestroyOnboardingTwo() { if (OnboardingSceneTwo != null) Destroy(OnboardingSceneTwo);}
    public void DestroyOnboardingThree() { if (OnboardingSceneThree != null) Destroy(OnboardingSceneThree); }
    public void DestroyOnboardingFour() { if (OnboardingSceneFour != null) Destroy(OnboardingSceneFour); }
    public void DestroyOnboardingFive()
    {
        if (OnboardingSceneFive != null)
        {
            Destroy(OnboardingSceneFive);
            DisplayOnboardingSix();
        }
    }
    public void DestroyOnboardingSix() { if (OnboardingSceneSix != null) Destroy(OnboardingSceneSix); }


}
