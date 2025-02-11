using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [Header("Ray�ݒ�")]
    public float rayDistance = 100f;

    [Header("�{�^���ݒ�")]
    public GameObject giveButton;
    public GameObject getButton;

    [Header("���C�t�Ǘ�")]
    [SerializeField] private LifeManager lifeManager;

    // �v���C���[���슮�����ɔ��s����C�x���g�iGameManager�őҋ@�j
    public event System.Action OnPlayerTurnCompleted;

    // ������ԊǗ��p�̕ϐ�
    private bool selectionMade = false;
    private string selectionResult = "";

    void Update()
    {
        // ���N���b�N�Ńt���X�R��I�����鏈��
        if (Input.GetMouseButtonDown(0))
        {
            ProcessPlayerClick();
        }
    }

    /// <summary>
    /// Raycast�Ńt���X�R��I�����鏈��
    /// </summary>
    private void ProcessPlayerClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            string objName = hit.collider.gameObject.name;
            if (objName.Contains("flask"))
            {
                int flaskNumber = int.Parse(objName.Replace("flask", ""));
                GameObject selectedFlask = hit.collider.gameObject;
                Vector3 originalPos = selectedFlask.transform.position;

                // ���o�F�t���X�R���ꎞ�I�Ɏ����グ��
                selectedFlask.transform.position += Vector3.up * 5f;

                // �{�^����\��
                giveButton.SetActive(true);
                getButton.SetActive(true);

                // ������Ԃ̃��Z�b�g
                selectionMade = false;
                selectionResult = "";

                StartCoroutine(WaitForPlayerSelection(flaskNumber, selectedFlask, originalPos));
            }
        }
    }

    /// <summary>
    /// �v���C���[�̑I��������ҋ@���āA���ʏ��������s����
    /// </summary>
    private IEnumerator WaitForPlayerSelection(int flaskNumber, GameObject selectedFlask, Vector3 originalPos)
    {
        while (!selectionMade)
        {
            yield return null;
        }

        // �{�^����\���A�t���X�R�ʒu�����ɖ߂�
        giveButton.SetActive(false);
        getButton.SetActive(false);
        selectedFlask.transform.position = originalPos;

        // �����Ńt���X�R�̌��ʂ�K�p���鏈���i��j
        Flask flaskComp = selectedFlask.GetComponent<Flask>();
        if (flaskComp != null)
        {
            if (selectionResult == "get")
            {
                Debug.Log($"�v���C���[�F�t���X�R {flaskNumber} �������ň���");
                // �����ň��ތ��ʏ���
            }
            else if (selectionResult == "give")
            {
                Debug.Log($"�v���C���[�F�t���X�R {flaskNumber} ��G�ɓn��");
                // �G�ɓn�����ʏ���
            }
        }
        else
        {
            Debug.LogWarning("�I�������t���X�R��Flask�R���|�[�l���g������܂���B");
        }

        // ���슮���C�x���g�̔��s
        OnPlayerTurnCompleted?.Invoke();
    }

    /// <summary>
    /// giveButton��OnClick�C�x���g�p���\�b�h
    /// </summary>
    public void OnGiveButtonClicked()
    {
        selectionResult = "give";
        selectionMade = true;
    }

    /// <summary>
    /// getButton��OnClick�C�x���g�p���\�b�h
    /// </summary>
    public void OnGetButtonClicked()
    {
        selectionResult = "get";
        selectionMade = true;
    }

    /// <summary>
    /// �Q�[���}�l�[�W���[����Ă΂��A����J�n���̏��������\�b�h
    /// </summary>
    public void EnableAction()
    {
        // ������Ԃ̏������ȂǁA�K�v�ȏ������L�q
        selectionMade = false;
        selectionResult = "";
    }
}
