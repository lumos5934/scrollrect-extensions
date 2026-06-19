# ScrollRect Effects
스크롤뷰와 관련하여 pivot 이나 anchor, layout group 형태에 제한 받지 않고 스냅, 스케일 등의 기능을 제공합니다. 

[ Usage ](#usage) <br>
[ API ](#api) <br>

<br>
<br>


## 🔧Usage

#### Snap
뷰포트의 중앙을 기준으로 Content 아래 자식들을 스냅 시킵니다.<br>
`OnEnable()`될 때 드래그가 끝났을때 자동으로 스냅됩니다. 스크롤 바를 이용하는경우 별도의 이벤트 트리거 추가가 필요합니다.


<img width="350" height="92" alt="image" src="https://github.com/user-attachments/assets/4e58058e-155c-4442-aa5e-c23bac120c75" /> <br>
<img width="421" height="422" alt="스냅" src="https://github.com/user-attachments/assets/9fe5b3fd-ffb0-42ba-bdbe-21c156033d50" /> <br>

<br>
<br>
<br>


#### Scale
뷰포트의 중앙을 기준으로 Content 아래 자식들의 scale을 변경합니다. <br>

<img width="326" height="190" alt="image" src="https://github.com/user-attachments/assets/986a1882-4fc2-4a78-b401-a8df252788cd" /> <br>
<img width="421" height="422" alt="스케일" src="https://github.com/user-attachments/assets/38f0fb9f-92c0-469d-b739-12afc8d7e920" /> <br>


<br>
<br>
<br>


#### Rotation
뷰포트의 중앙을 기준으로 Content 아래 자식들의 rotation을 변경합니다. <br>
`Use Mirror` 옵션을 통해 가로 혹은 세로로 반대 작용을 할 수 있고 방사형 구조에서는 보장되지 못합니다.

<img width="327" height="208" alt="image" src="https://github.com/user-attachments/assets/08127b4c-5100-4ef5-95d3-17695f84fc42" />
<img width="326" height="271" alt="image" src="https://github.com/user-attachments/assets/6d13bf95-80f9-489e-97e8-fb22a4b3abd2" /><br>
<img width="421" height="422" alt="로테이션" src="https://github.com/user-attachments/assets/95cffa69-9214-48a7-a23b-93a7903d377d" /><br>
<img width="421" height="422" alt="로테이션 미러" src="https://github.com/user-attachments/assets/8f348634-6346-400a-b162-00e885e1d28e" />


<br>
<br>
<br>

## 📖API
* #### ScrollRectEffectCore
**`Effects`** : 사용중인 효과들 입니다. <br>
**`Items`** : 관리중인 아이템 입니다.<br>
**`UpdateItems()`** : 강제로 아이템들을 업데이트합니다.<br>

<br>
<br>

* #### ScrollRectEffect
**`OnRefreshed(items)`** : 아이템들을 새로 생성했을때 실행됩니다. <br>
**`OnUpdated(items)`** : 아이템들을 매프레임 업데이트 할때마다 실행됩니다. <br>


<br>
<br>

* #### ScrollRectSnapEffect
**`SnapCurve`** : 스냅시 이동에 대한 애니메이션 커브입니다. <br>
**`Items`** : 관리중인 아이템 입니다.<br>
**`Snap(useAnimation)`** : 뷰포트의 중앙으로 스냅시킵니다. usAnimation을 통해 애니메이션 사용 여부를 결정 할 수 있습니다. <br>
**`Snap(target, useAnimation)`** : 특정 타겟으로 스냅시킵니다. usAnimation을 통해 애니메이션 사용 여부를 결정 할 수 있습니다. <br>

<br>
<br>

* #### ScrollRectLayoutEffect
**`Curve`** : 각 효과들이 사용하는 애니메이션 커브입니다. <br>
**`EffectDistanceX`** : 효과가 적용될 최대 X 거리입니다.<br>
**`EffectDistanceY`** : 효과가 적용될 최대 Y 거리입니다. <br>

<br>
<br>


