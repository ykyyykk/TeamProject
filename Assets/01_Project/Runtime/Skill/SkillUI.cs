﻿using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image[] skillImages;
    [SerializeField] private SkillSO[] skillSO;
    [SerializeField] private Image[] skillCDImages;
    [SerializeField] private Sprite selectedFrame;
    [SerializeField] private Sprite defaultFrame;

    public void Init(SkillSelector skillSelector, SkillShooter skillShooter)
    {
        skillSelector.ChangeSelectSkill.AddListener(ChangeSelectSkillFrame);
        for (int i = 0; i < skillSO.Length; i++)
        {
            skillShooter.Cooldowning.AddListener(UICoolDown);
        }
    }

    private void ChangeSelectSkillFrame(int currentIndex, int previousIndex)
    {
        //不要調換順序
        skillImages[previousIndex].sprite = defaultFrame;
        skillImages[currentIndex].sprite = selectedFrame;
    }

    private void UICoolDown(int currentIndex, float skillCD, float skillRate)
    {
        //Debug.Log(currentIndex);
        skillCDImages[currentIndex].fillAmount = skillCD / skillRate;
    }
}