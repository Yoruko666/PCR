# PCR
复刻《公主连结！Re:Dive》项目。

### Spine插件入门

- 引入命名空间
```C#
using Spine;
using Spine.Unity;
```

- 获取组件
```C#
SkeletonAnimation spine = GetComponent<SkeletonAnimation>();
```

- 播放动画
```C#
TrackEntry SetAnimation(int trackIndex, string animName, bool loop);
```

- 监听动画
```C#
spine.AnimationState.Complete += OnAnimComplete;

void OnAnimComplete(TrackEntry entry) {
    if (entry.Animation.Name == "attack") {
        Debug.Log("攻击动画播放完毕");
        spine.AnimationState.SetAnimation(0, "idle", true);
    }
}
```

- Spine 编辑器自定义帧事件
```C#
spine.AnimationState.Event += OnSpineEvent;

void OnSpineEvent(TrackEntry entry, Event evt) {
    switch (evt.Data.Name) {
        case "hit":
            Debug.Log("触发伤害判定");
            break;
        case "footstep":
            // 播放脚步声
            break;
    }
}
```

- 控制播放速度
```C#
spine.AnimationState.TimeScale = 1f;
```

- 立刻停止动画、重置姿势
```C#
spine.AnimationState.ClearTracks();
spine.Skeleton.SetToSetupPose();
```

### 一些有用的网址：

[公主连结BWiki](https://wiki.biligame.com/pcr/%E9%A6%96%E9%A1%B5)\
[公主连结FandomWiki](https://princess-connect.fandom.com/wiki/Princess_Connect!_Re:Dive_Wiki)\
[蘭德索爾圖書館](https://pcredivewiki.tw/)\
[干炸里脊资源（©Cygames）](https://redive.estertion.win/)\
[【公主连结Re:Dive】游戏站位机制](https://zhuanlan.zhihu.com/p/145043002)\
[【公主连结Re:Dive】游戏机制之普攻和技能机制](https://zhuanlan.zhihu.com/p/148423807)\
[【公主连结Re:Dive】游戏机制之公式整合](https://zhuanlan.zhihu.com/p/145042599)\
[【公主连结Re:Dive】游戏机制之tp机制](https://zhuanlan.zhihu.com/p/151069934)\
[【公主连结Re:Dive】游戏机制之先后手的机制](https://zhuanlan.zhihu.com/p/149200253)\
[【公主连结/游戏机制】移动&站位机制·修正版](https://www.bilibili.com/opus/454873187389458535)\
[【教程】如何提取公主连结游戏动画素材](https://www.bilibili.com/opus/801111052800491733)\