using UnityEngine;

// �t���X�R�̎�ށi�Ł^���^�����_�����ʁj
public enum FlaskType
{
    Poison,
    Water,
    RandomEffect
}

public class Flask : MonoBehaviour
{
    // ���݂̃t���X�R�̒��g
    public FlaskType flaskType;
    // �����_�����ʂ̏ꍇ�A�ǂ̌��ʂ��i���ڍׂ� RandomEffect �񋓑̂��Q�Ɓj
    public RandomEffect randomEffect;

    /// <summary>
    /// �t���X�R�̒��g�����肷��B
    /// �܂�50%�̊m���Łu���v�Ƃ��A�c��́u�Łv�Ƃ���B
    /// �u���v�ƂȂ����ꍇ�A�����30%�̊m���Ń����_�����ʁi���g RandomEffect�j�ɕύX����B
    /// </summary>
    public void DetermineContents()
    {
        // 50%�Ő��itrue�j�^�Łifalse�j������
        bool isWater = Random.value < 0.5f;
        if (isWater)
        {
            // ���̏ꍇ�A�����30%�̊m���Ń����_������
            if (Random.value < 0.3f)
            {
                flaskType = FlaskType.RandomEffect;
                // RandomEffect �񋓑̂��烉���_���Ɍ��ʂ�I��
                var effects = System.Enum.GetValues(typeof(RandomEffect));
                randomEffect = (RandomEffect)effects.GetValue(Random.Range(0, effects.Length));
            }
            else
            {
                flaskType = FlaskType.Water;
            }
        }
        else
        {
            flaskType = FlaskType.Poison;
        }
        Debug.Log($"{gameObject.name} �̒��g: {flaskType}" +
                  (flaskType == FlaskType.RandomEffect ? $" ({randomEffect})" : ""));
    }
}
