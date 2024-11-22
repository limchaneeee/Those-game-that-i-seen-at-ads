# 프로젝트명: Those game:that i seen at ads
> 내일배움 캠프 Unity 6기 유니티 심화주차 프로젝트  
> 2024.11.15 ~ 2024.11.22
 
## 맴버 및 역할 분담
### 팀소개
|  |이름|깃허브|
|---|---|:---|
|팀장|임찬|https://github.com/limchaneeee
|팀원|김진서|https://github.com/Unity-js
|팀원|박참솔|https://github.com/Real-pine
|팀원|안성찬|https://github.com/sungchanahn
|팀원|홍신영|https://github.com/Hongshinyoung

## 게임 소개
- 참고게임(쇼츠광고로 나오는 그거)의 열받는 요소를 착안한 게임입니다.
- 레퍼런스가 된 게임은 Arrow a row와 라스트워입니다.   
</br>

![image](https://ifh.cc/g/wQs51L.gif)

## 기술스택
- Language: C#
- IDE: Visual Studio, Rider
- GameEngine: Unity - 2022.3.17f1

## 프로젝트 프레임
> 클릭 시 확대가능

![image](https://ifh.cc/g/DXwaKF.jpg)

## ⚙조작 방법
- 좌우 이동: A D
- Pause: ESC

## ⚔아이템 & Obstacle
- 공격속도 증가, 데미지 증가   
![image](https://github.com/user-attachments/assets/5bffa9e4-ae9b-4acb-b457-dae1da368208)   
- 부딪힌 클론 제거   
![image](https://github.com/user-attachments/assets/e6e7c32d-ac82-4714-a0f3-b7b6aade80d9)    
- 클론 수 증가 or 감소   
![image](https://github.com/user-attachments/assets/7ef0e90f-6003-4e12-a20d-46d78289264c)    

## 🧛‍♂️보스
![image](https://github.com/user-attachments/assets/5c9b7267-ddf1-445c-ba75-dc4f727f13ec)
- 진행도 100%시 스폰
- 장애물, 적 소환

## 🧟‍♂적
![image](https://github.com/user-attachments/assets/c78faed0-39e3-4d8f-ad63-2d4dc5c32364)
- Nav Mesh Agent를 이용한 이동
- 플레이어 충돌 시 플레이어 사망

## 🦸‍♂️플레이어
![image](https://github.com/user-attachments/assets/264c7af2-ddd0-41f2-b12d-fb1467638d1a)
- 총알 발사
- 좌우 이동
- 적과 충돌 시 사망

## 📖사용 에셋
- 플레이어
https://assetstore.unity.com/packages/3d/characters/humanoids/toon-soldiers-ww2-demo-85702
- 적 & 보스
https://assetstore.unity.com/packages/3d/characters/toony-tiny-people-demo-113188
- 환경
https://assetstore.unity.com/packages/3d/environments/urban/lowpoly-modern-city-decorations-set-66070
- 파티클
https://assetstore.unity.com/packages/vfx/particles/hit-impact-effects-free-218385
- 사운드
  - 배경음: https://assetstore.unity.com/packages/audio/music/electronic/eletronic-music-pack-267422
  - 총SFX: https://assetstore.unity.com/packages/audio/sound-fx/shooting-sound-177096
  - 기타SFX: https://assetstore.unity.com/packages/audio/sound-fx/rpg-essentials-sound-effects-free-227708

## 기술
- Object Pooling을 이용한 다양한 오브젝트 개체 수 관리(총알, 적, 장애물)
- SpawnManager를 이용한 다양한 생성 관리
- UIManager를 이용하여 다양한 팝업 관리

## 🚀트러블슈팅(TroubleShooting)
<details>
<summary>설계되지않은 상태에서 진행한 레벨디자인, 스테이지구현</summary>
<div markdown="1">

레벨디자인을 전혀 고려하지않고 만들었다가. 마감 시간이 오히려 넉넉하다는 것을 깨닫고, 그제서야 레벨디자인과 스테이지설계를 진행했습니다. 

객체지향적프로그래밍의 중요성 여기서 깨달았습니다. 막상 시간에 쫓겨 레벨디자인을 하려고보니 활용할 수 있는 것들이 제한적이었습니다(사고의 폭이 좁은 것도 한몫했다고 생각해봅니다.)

그래서 억지로 생각해낸게 각 스테이지데이터를 SO에 저장한 뒤 불러와서 스폰매니저한테 각 스테이지마다 다르게 스폰하기였습니다. 구현은 했지만 csv를 활용해 파싱하는 방법으로 구현해볼걸 하는 아쉬움이 남습니다.

</div>
</details>

</br>

<details>
<summary>보스 캐릭터 이동 문제</summary>
<div markdown="1">

![이미지](https://ifh.cc/g/oMNb5O.png)
- 문제: IEnumerator 내에서 보스를 목표 위치로 이동시키는 코드를 사용했지만, 이동 중에 currentBoss가 null일 경우를 처리하지 않으면 예외가 발생 할 수 있었음.
- 해결: 이동 중 currentBoss가 null이면 yield break로 코루틴을 종료시켜 오류를 방지하도록 수정했음.

</div>
</details>

</br>

<details>
<summary>캐릭터 충돌 문제</summary>
<div markdown="1">

![이미지](https://ifh.cc/g/p92OLc.jpg)
![이미지](https://ifh.cc/g/xRrfPn.jpg)
- 문제: 플레이어 캐릭터 - 클론, 클론 - 클론이 서로 밀어내거나 심하면 튕겨나가는 문제 발생
- 해결: Physics Material을 새로 만들고 Bounciness와 Friction을 0으로 맞춰 클론의 Collider - Material에 적용. 또 클론의 rigidbody의 mass를 작게(0에 가깝게) 만들어 플레이어를 밀치지 못하게 하였다.

</div>
</details>

</br>

<details>
<summary>인스펙터 할당문제</summary>
<div markdown="1">

![이미지](https://ifh.cc/g/PgY89H.png)
- 문제: UI에서 Image를 ComponentInchildern으로 가져오는 중 자식의 이미지가 아닌 자신의 이미지를 가져오는 문제 발생.
- 해결: ComponentInchildern는 자기자신 먼저 확인하고, 자식을 확인한다는 것을 배웠고, 인스펙터에서 직접 등록으로 변경하여 해결.

</div>
</details>

</br>

<details>
<summary>씬전환 시 발생하는 UI 버그</summary>
<div markdown="1">

- 문제
```cs
private void OnMainBtnClicked()
    {
        SceneManager.LoadScene("StartScene")
        Hide()
        UIManager.Instance.ClearAllUI()
    }
```
씬 전환 시 계속 UIManager에서 리스트에 해당하는 UI가 없다고 오류가 뜨고 NullReferenceException이 발생하고 별의 별 문제가 다 일어났습니다.

- 해결: 곰곰히 생각해보니 씬을 전환하면 전환되면서 해당 오브젝트들은 파괴되는데 LoadScene을하고나서 Hide()와 ClearAllUI()가 실행되지 않을 것입니다.
  또한 메서드 실행 순서를 바꿔 Hide() -> ClearAllUI() -> LoadScene() 순으로 코드를 실행시켜도 마찬가지로 해당 UI오브젝트는 Hide에서 이미 파괴되기때문에
  씬전환이 일어나지 않습니다.
  Hide()메서드는 결과적으로 UIManager의 Hide()를 실행시키는 것이기 때문에, 일단 UIManager에서 해당 UI를 없애는 Hide()와 LoadScene()을 같이 실행시켜주는
  HideAndTransition()이라는 메서드를 새로 만들어줬습니다.
  ```cs
  public void HideAndTransitionScene(string uiName, string sceneName)
    {
        UIBase go = uiList.Find(obj=> obj.name == uiName);
        
        uiList.Remove(go);
        Destroy(go.canvas.gameObject);
        
        GameManager.Instance.LoadScene(sceneName);
    }
  ```
  게임매니저의 LoadScene()메서드는 기존 씬매니저의 LoadScene()에서 UI리스트를 초기화하는 로직을 추가해놓은 메서드입니다.
  따라서, UI없애기와 씬전환이 동시에 발생해야하는 UI들에게는 Hide()가 아닌 HideAndTransition()을 사용하면서 문제를 해결했습니다.

</div>
</details>



