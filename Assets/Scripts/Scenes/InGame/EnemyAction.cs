using System.Collections;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] FlaskManager flaskManager;
    int which;

    public IEnumerator EnemyTurn()
    {
        // �G���I�ԃt���X�R�F�Տ�Ɏc�钆���烉���_���ɑI��
        do
        {
            which = Random.Range(0, flaskManager.flaskArray.Length);
        } while (!flaskManager.flaskArray[which].activeSelf);

        // �G�̑I�����W�b�N�i�L���ȑI�������m���ōs�����A�ڍׂ͖���j
        int randomBias = Random.Range(1, 6);

        yield return new WaitForSeconds(2f);
    }
}
