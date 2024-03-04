# Alien Report


## 소개
### CCTV를 통해 집안에서 발생하는 이상 현상들을 감시하고 보고해라 

## 개발 기간
- 24.02.26 ~ 24.03.04

## 멤버
- 이상민(팀장) : 프로젝트 관리, 카메라 배치, 이상현상 구현
- 김유원 : 사운드 작업 및 파티클 시스템 추가, 이상현상 구현
- 유호진 : 포스트프로세싱, 카메라 필터 및 광원효과 작업, 이상현상 구현
- 신채윤 : 게임 로직 구현, UI 작업

## 개발 환경
- Engine : Unity 2022.3.2f1
- Language : C#

## 구성
### Title
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/26eb49df-c1ea-48d6-be47-c05b92b12278)

### LoadingSecene
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/0eced67a-cf67-441c-a9d0-50fe39aa294b)

### MainScene
- 각 방의 카메라들

![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/5948b7f4-9958-4b0f-8fb1-38362839f761)
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/c27274b5-15ad-4e11-954f-645d04208dea)
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/0cb5bb7d-b5ea-4ac6-b50c-cb0535281887)
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/177bef9b-d832-40ca-b3bc-99d76f091325)
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/5cbbac7e-16ec-4e07-9539-d7abaf09a646)
![image](https://github.com/SPRT-UNITY/Anomaly/assets/37549333/2473455c-4115-4e0b-85ad-47bfcbed9cba)

## 구현 사항
#### 1. 맵의 구조와 오브젝트 배치
 - 3d 오브젝트들을 활용하여 일반 가정집 같은 느낌의 맵을 만들었습니다.
 - 동시에 가정에 있을 법한 물건들을 배치하여 더욱 현실감 있는 느낌을 줍니다.

#### 2. 조명과 포스트프로세싱
 - 공포스러운 분위기를 연출하기 위해 조명을 어둡게 설정하였습니다.
 - 포스트프로세싱을 통해 Material들을 더 자연스럽게 표현하도록 구성했습니다.

#### 3. 카메라와 필터
 - Cinemachine을 이용해 카메라를 배치하고 여러 카메라 화면을 전환할 수 있도록 구현하였습니다.
 - 카메라 필터를 이용해 실제 CCTV를 보는 것 처럼 화면에 특수 효과를 넣었습니다.

#### 4. 이상 현상
 - 게임이 시작되면, 무작위 주기별로 맵에 이상 현상이 나타나기 시작합니다.
 - 물체의 이동 및 사라짐, 없던 물건이 생기거나 침입자가 나타나는 등 다양한 종류의 이상 현상들이 준비되어 있습니다.
 - 이상 현상들은 GameObject들로 구성되어 이상 현상이 발생함에 따라 enable 되어 나타납니다.

#### 5. 게임의 진행
 - 화면 양옆의 버튼을 통해 카메라 화면을 전환할 수 있습니다. 화면을 전환해가며 이상 현상이 나타나지 않았는지 확인해야 합니다.
 - 이상 현상이 나타났을 시, 이상현상을 향해 마우스 왼쪽 버튼을 꾹누르면 이상 현상을 신고할 수 있습니다.
 - 이상 현상 중에는 마우스 왼쪽 버튼을 통해 신고할 수 없는 종류들도 있습니다. 이 경우엔 마우스 왼쪽 버튼을 통해 직접 이상 현상의 종류를 선택해 신고할 수 있습니다.
 - 이상 현상을 신고하고 나면 3초 후, 신고가 접수되어 이상 현상이 해결됩니다.

#### 6. 게임의 목표와 게임오버 조건
 - 이상 현상이 3개가 쌓일 경우, 경고 문구가 나타납니다. 만일 이상 현상 4개가 쌓일 시 게임 오버됩니다.
 - 집안에서 나타나는 이상 현상들을 해결하면서, 아침 6시까지 버티는 것이 게임의 목표입니다.
 - 이상 현상들을 해결하지 못하여 게임 오버 될 경우, 게임 오버 화면에서 놓친 이상 현상들을 확인할 수 있습니다.

## 게임 기획과 와이어프레임
#### 와이어 프레임
https://teamsparta.notion.site/f87774c1a2c94b78b2d9a29016016b18
https://teamsparta.notion.site/a507a196682e4b539bb9e299ae3f13dd

#### 사용 에셋
https://teamsparta.notion.site/f97098fdc1b34d3ab9ea13ef5760f2ef
