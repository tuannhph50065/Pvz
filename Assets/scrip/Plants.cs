using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện cần thiết để quản lý scene
using UnityEngine.UI; // Thư viện cần thiết để làm việc với UI

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Tên của scene mà bạn muốn chuyển đến

    // Hàm gọi khi nhấn nút
    public void ChangeScene()
    {
        // Kiểm tra xem sceneToLoad có hợp lệ không và chuyển đến scene đó
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Tên scene không được gán.");
        }
    }
}
