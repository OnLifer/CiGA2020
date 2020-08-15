玩法描述：
通过各种防御或逃避类的卡牌撑过一波波的蚂蚁攻击

#######################################################################################################

功能流程:
开始：在开始界面没有其他选项，提示点击任意按键进入游戏

播放开场动画

全局规则：
    1.初始化丧值
    2.当 丧值=0时游戏立即结束 bad end；
    3.当 丧值>0 且 关卡序列全部执行完毕时游戏结束 good end；
    4.丧值的变化会影响游戏的背景图片（房屋状态），通过配表数值来做判断条件。
    5.除了初始化默认的手牌上限，还有一张额外的发呆卡并不在这个计数行列中

出现第一个序列中的敌人
#词语定义：每个敌人成为每个关卡序列，每个关卡序列中会有多个回合。

关卡序列规则：
    关卡开始后————初始化体力、初始化所有卡牌、初始化怪物状态
        回合规则：
            1.开始当前关卡第一回合，player默认先手
            2.每个回合开始后————初始化体力、补充手牌至默认上限数量、执行带有且符合触发执行条件的 状态（buff or debuff） **_STATUS
            3.当体力值为0时，敌人将会开始行动，然后回合结束
            4.当前回合player可以不做出行动，打出发呆牌即可，之后敌人将会开始行动，然后回合结束

