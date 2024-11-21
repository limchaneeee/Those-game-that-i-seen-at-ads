# 프로젝트명: Those game:that i seen at ads
> 내일배움 캠프 Unity 6기 유니티 심화주차 프로젝트  
> 2024.11.15 ~ 2024.11.22
 
### 맴버 및 역할 분담
## 팀소개
|  |이름|깃허브|
|---|---|:---|
|팀장|임찬|https://github.com/limchaneeee
|팀원|김진서|https://github.com/Unity-js
|팀원|박참솔|https://github.com/Real-pine
|팀원|안성찬|https://github.com/sungchanahn
|팀원|홍신영|https://github.com/Hongshinyoung

## 게임 소개
- 참고게임(쇼츠광고로 나오는 그거)의 열받는 요소를 착안한 게임

### 조작 방법
- 좌우 이동: A D
- Pause: ESC

### 아이템 & Obstacle
- 공격속도 증가, 데미지 증가   
![image](https://github.com/user-attachments/assets/5bffa9e4-ae9b-4acb-b457-dae1da368208)   
- 부딪힌 클론 제거   
![image](https://github.com/user-attachments/assets/e6e7c32d-ac82-4714-a0f3-b7b6aade80d9)    
- 클론 수 증가 or 감소   
![image](https://github.com/user-attachments/assets/7ef0e90f-6003-4e12-a20d-46d78289264c)    

### 보스
![image](https://github.com/user-attachments/assets/5c9b7267-ddf1-445c-ba75-dc4f727f13ec)
- 진행도 100%시 스폰
- 장애물, 적 소환

### 적
![image](https://github.com/user-attachments/assets/c78faed0-39e3-4d8f-ad63-2d4dc5c32364)
- Nav Mesh Agent를 이용한 이동
- 플레이어 충돌 시 플레이어 사망

### 플레이어
![image](https://github.com/user-attachments/assets/264c7af2-ddd0-41f2-b12d-fb1467638d1a)
- 총알 발사
- 좌우 이동
- 적과 충돌 시 사망

### 사용 에셋
- 플레이어
https://assetstore.unity.com/packages/3d/characters/humanoids/toon-soldiers-ww2-demo-85702
- 적 & 보스
https://assetstore.unity.com/packages/3d/characters/toony-tiny-people-demo-113188
- 환경
https://assetstore.unity.com/packages/3d/environments/urban/lowpoly-modern-city-decorations-set-66070

### 기술
- Object Pooling을 이용한 다양한 오브젝트 개체 수 관리(총알, 적, 장애물)
- SpawnManager를 이용한 다양한 생성 관리
- UIManager를 이용하여 다양한 팝업 관리
