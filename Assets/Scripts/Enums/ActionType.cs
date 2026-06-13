/*
 * ActionType
 *  1：伤害
 *  3：造成位移
 *  4：回复HP
 *  6：护盾
 *  8：加速/减速/无法移动
 *  10：施加Buff
 *  12：施加黑暗状态
 *  16：回复TP
 *  21：无敌
 *  48：持续回复HP
 *  59：重伤
 *  90：被动技能提升
 *  102：每次攻击伤害增加
 */

public enum eActionType
{
    Damage  = 1,
	Offset  = 3,
    Heal    = 4,
    Shield  = 6,
    Buff    = 10,
}