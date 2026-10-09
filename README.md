# Altium test task

## Phase 1 — Test File Generator
As a developer, I want to generate a large text file containing numbered strings and a configurable number of duplicate strings, so that I can test the correctness and performance of the sorting utility.

**Input parameters**
- `outputFilePath` — path to the generated file.
- `targetFileSizeBytes` - size of the generated file in bytes. (?)
- `targetLineCount` - size of the generated file in lines. (?)
- `duplicateWordsCount` — number of distinct string values that must appear minimum 2 times in the generated file.

**Output**
- A text file in which every line follows the format `<number>. <string>`.
- The generated file is valid input for the sorter.
- Exactly `duplicateWordsCount` distinct string values occur more than once, subject to the agreed interpretation of this parameter.

--------------
**Tasks**
ID	Task	Результат
G1	Определить формат строки и правила генерации данных	Спецификация формата
G2	Реализовать генератор уникальных и повторяющихся String-значений	Контролируемые дубликаты
G3	Реализовать генерацию Number для каждой строки	Числа в допустимом диапазоне
G4	Организовать потоковую запись в файл	Низкое потребление RAM
G5	Добавить проверку входных параметров и ошибок файловой системы	Предсказуемое поведение
G6	Добавить тесты генератора	Проверка формата, размера и количества дубликатов
G7	Измерить скорость генерации больших файлов	Время генерации и пропускная способность

## Phase 2 — File Sorter
As a developer, I want to sort a large text file containing numbered strings, so that I obtain a correctly ordered output file without requiring the entire input file to fit into memory.

**Input parameters**
- `inputFilePath` — path to the input text file.
- `memoryLimitBytes` - size of memory to use (all available as default).
- `tempDirectory` - path to temp directory (system temp as default).

**Output**
A sorted text file in which each line preserves its original content.
Lines are ordered by the String part in ascending order.

If two String values are equal, their lines are ordered by Number in ascending order.
Duplicate lines and duplicate String values are preserved.

The sorting process supports files significantly larger than the available RAM, including files of approximately 100 GB.

-----------
**Tasks**
ID	Task	Результат
S1	Реализовать парсер формата <number>. <string>	Корректное разделение Number и String
S2	Определить и реализовать правила сравнения строк	Детерминированная сортировка
S3	Реализовать сравнение по Number при равных String	Вторичный ключ сортировки
S4	Реализовать внешнюю сортировку (external merge sort)	Сортировка файлов больше RAM
S5	Реализовать создание и слияние промежуточных файлов	Контролируемое использование памяти и диска

---------

S6	Реализовать обработку ошибок ввода-вывода	Корректное завершение при ошибках
S7	Реализовать запись итогового файла	Полный отсортированный результат
S8	Добавить unit-тесты и integration-тесты	Проверка корректности сортировки
S9	Провести performance-тестирование на больших файлах	Время выполнения и использование ресурсов
