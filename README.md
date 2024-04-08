# irairabou
卒業制作展に出展したゲームになります。

## 開発環境
Unity 2020.3.20f1

## プログラム命名規則
|種類|表記法|例|
:---|:---|:---
|メンバー変数|キャメルケース|Transform **selfTrans**|
|プロパティ|パスカルケース|Transform **SelfTrans**{get;set;}|
|ローカル変数|キャメルケース|var **playerCharacter**|
|メソッド名|パスカルケース|void **OnDestroy**()|
|メソッド引数名|キャメルケース|void Damage(int **value**)|
|定数|パスカルケース|const float **FadeTime** = 1.0f;|
|列挙体|パスカルケース|enum **ColliderType**<br>{<br>&nbsp; &nbsp; **Box**,<br>&nbsp; &nbsp; **Sphere**,<br>}|
|namespace|パスカルケース|namespace **Sound**|

## オブジェクト命名規則
1. 基本的にはオブジェクトの機能を示す名前を付ける　**例：InputSystem**

1. オブジェクトプールするためなどにシーン再生後に生成されるものは、生成時に名前を付ける((Clone)が付いた状態にしない)
   - エフェクトや敵を複数生成する場合は、番号を名前に含める　**例：Slime_01**

1. UIは名前の先頭にUI_をつける　**例：UI_PlayerStatus**

1. Playerや一部UIなどの階層を持つオブジェクトは以下のように命名する
   1. Enemy(Slime)の例(子要素にSlime_01_Modelといったように親の名前を付ける必要はない)
      - Slime_01
        - Model
   1. PlayerStatusUIの例(子要素はUIの種類を名前に含む)
      - UI_PlayerStatus
        - Image_Icon
        - Text_Name
        - HealthBar(UI系コンポーネントがついていない場合は基本的な命名法則)
          - Image_Border
          - Image_Bar　


## ブランチ規則
1. デフォルトブランチはdevelopブランチとする  

1. 個人の作業ブランチはfeature/個人名/作業内容とする **例：feature/fujishima/datacreate**

## このゲームでの専門的用語  

1. ステージ  
  →プレイヤーがプレイする一単位。複数作るかは未定。

1. ユニット  
→ステージを構成するうちの一面の事を呼ぶ。これを四つ囲み一ステージとする。

1. 上ギミック  
→ユニットを構成する単位。ユニットの上部を担当する。下ギミックと合わせてユニットとする。

1. 下ギミック  
→ユニットを構成する単位。ユニットの下部を担当する。上ギミックと合わせてユニットとする。


