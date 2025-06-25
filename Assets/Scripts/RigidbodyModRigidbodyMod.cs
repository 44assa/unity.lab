using UnityEngine;

public class RigidbodyMod : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _initialPosition; // Сохраняем начальную позицию шара
    private Quaternion _initialRotation; // Сохраняем начальное вращение шара

    void Start()
    {
        // Получаем компонент Rigidbody с этого же игрового объекта
        _rb = GetComponent<Rigidbody>();

        // Сохраняем текущие позицию и вращение как начальные
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        // Изначально делаем шар "нефизическим" и неподвижным
        _rb.isKinematic = true;      // Unity не управляет им физически
        _rb.useGravity = false;      // Гравитация выключена
        _rb.linearVelocity = Vector3.zero; // Обнуляем скорость (если была)
        _rb.angularVelocity = Vector3.zero; // Обнуляем угловую скорость (если была)

        // Задаем начальные физические свойства шара
        _rb.mass = 1.0f;             // Начальная масса (1 кг)
        _rb.linearDamping = 0.5f;             // Начальное сопротивление воздуху (немного тормозит, чтобы успеть среагировать)
        _rb.angularDamping = 0.05f;     // Начальное угловое сопротивление (очень медленно останавливает вращение)

        Debug.Log("Сцена запущена. Нажмите Пробел для запуска шара.");
    }

    void Update()
    {
        // --- Управление запуском и перезапуском шара ---
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Возвращаем шар в начальную позицию и вращение
            _rb.position = _initialPosition;
            _rb.rotation = _initialRotation;

            // Сбрасываем все физические скорости
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;

            // Делаем шар "физическим" и включаем гравитацию
            _rb.isKinematic = false; // Теперь Unity будет управлять им
            _rb.useGravity = true;   // Включаем гравитацию, чтобы шар падал

            // Даем шару начальный толчок вперед
            // Значение 10f - это сила толчка. Можешь менять его, чтобы шар летел быстрее/медленнее.
            _rb.AddForce(transform.forward * 50f, ForceMode.Impulse);

            Debug.Log("Шар запущен!");
        }

        // --- Управление свойствами шара в полёте ---

        // Управление сопротивлением воздуху (Drag)
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Клавиша '1' (над буквами)
        {
            _rb.linearDamping = 0.1f; // Низкое сопротивление: летит дальше и быстрее
            Debug.Log("Сопротивление воздуху (Drag): Низкое (0.1)");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Клавиша '2'
        {
            _rb.linearDamping = 2.0f; // Среднее сопротивление: быстрее тормозит
            Debug.Log("Сопротивление воздуху (Drag): Среднее (2.0)");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // Клавиша '3'
        {
            _rb.linearDamping = 10.0f; // Высокое сопротивление: очень быстро тормозит, как в воде
            Debug.Log("Сопротивление воздуху (Drag): Высокое (10.0)");
        }

        // Управление угловым сопротивлением (Angular Drag) - как быстро шар перестает вращаться
        if (Input.GetKeyDown(KeyCode.Q)) // Клавиша 'Q'
        {
            _rb.angularDamping = 0.05f; // Низкое угловое сопротивление: шар будет долго вращаться после удара
            Debug.Log("Угловое сопротивление (Angular Drag): Низкое (0.05)");
        }
        if (Input.GetKeyDown(KeyCode.W)) // Клавиша 'W'
        {
            _rb.angularDamping = 5.0f; // Высокое угловое сопротивление: шар очень быстро остановит вращение
            Debug.Log("Угловое сопротивление (Angular Drag): Высокое (5.0)");
        }

        // Включение/отключение гравитации
        if (Input.GetKeyDown(KeyCode.G)) // Клавиша 'G'
        {
            _rb.useGravity = !_rb.useGravity; // Переключаем значение (было true, станет false; было false, станет true)
            Debug.Log("Гравитация: " + (_rb.useGravity ? "ВКЛЮЧЕНА" : "ВЫКЛЮЧЕНА"));
        }

        // Изменение массы шара
        if (Input.GetKeyDown(KeyCode.M)) // Клавиша 'M'
        {
            if (_rb.mass == 1.0f) // Если текущая масса 1 кг
            {
                _rb.mass = 100.0f; // Делаем шар тяжелым (100 кг)
                Debug.Log("Масса шара: Тяжелая (100 кг)");
            }
            else // Если текущая масса не 1 кг (значит, 100 кг)
            {
                _rb.mass = 1.0f; // Делаем шар легким (1 кг)
                Debug.Log("Масса шара: Легкая (1 кг)");
            }
        }
    }
}