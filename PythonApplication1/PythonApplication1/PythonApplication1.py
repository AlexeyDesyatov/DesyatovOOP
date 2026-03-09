import random

# Данные генераторов
generators = [
    {'id': 1, 'max': 54},
    {'id': 2, 'max': 120},
    {'id': 3, 'max': 190},
    {'id': 4, 'max': 120},
    {'id': 5, 'max': 54},
    {'id': 6, 'max': 120}
]

# Параметры
min_percent = 76.91689083 / 100
max_percent = 90.47291438 / 100
target_percent = 84.37346 / 100

# Расчёты
total_max = sum(g['max'] for g in generators)
target_power = total_max * target_percent

print("=" * 100)
print(f"Общая установленная мощность: {total_max} МВт")
print(f"Целевая мощность ({target_percent*100:.5f}%): {target_power:.6f} МВт")
print("=" * 100)

# Рассчитываем мин и макс для каждого генератора
for g in generators:
    g['min_power'] = g['max'] * min_percent
    g['max_power'] = g['max'] * max_percent

# Проверяем возможность распределения
total_min = sum(g['min_power'] for g in generators)
total_max_allowed = sum(g['max_power'] for g in generators)

print(f"\nСумма минимумов: {total_min:.6f} МВт")
print(f"Сумма максимумов: {total_max_allowed:.6f} МВт")
print(f"Целевая сумма: {target_power:.6f} МВт")
print(f"Возможно распределить: {total_min <= target_power <= total_max_allowed}")

if not (total_min <= target_power <= total_max_allowed):
    print("ОШИБКА: Невозможно распределить мощность в заданных пределах!")
    exit()

# ИСПРАВЛЕННЫЙ АЛГОРИТМ распределения
random.seed(52)

# Начинаем с минимальных значений
for g in generators:
    g['power'] = g['min_power']

remaining = target_power - total_min

# Создаем список генераторов для случайного распределения
gen_indices = list(range(len(generators)))
random.shuffle(gen_indices)

# Распределяем остаток с проверкой ограничений
for idx in gen_indices:
    g = generators[idx]
    
    # Сколько ещё можно добавить этому генератору
    can_add = g['max_power'] - g['power']
    
    # Сколько должны получить остальные генераторы (минимум)
    remaining_gens = [generators[i] for i in gen_indices if generators[i]['id'] != g['id'] and generators[i]['power'] < generators[i]['max_power']]
    min_for_others = sum(0 for _ in remaining_gens)  # Могут получить 0
    
    # Максимум, который можем дать этому генератору
    max_can_give = min(can_add, remaining - min_for_others)
    
    if max_can_give > 0 and remaining > 0:
        # Случайное значение от 0 до max_can_give
        add = random.uniform(0, max_can_give)
        # Но не больше чем осталось
        add = min(add, remaining)
        g['power'] += add
        remaining -= add

# Если что-то осталось, распределяем итеративно
iteration = 0
max_iterations = 1000
while remaining > 0.0001 and iteration < max_iterations:
    iteration += 1
    distributed_this_round = False
    
    for idx in gen_indices:
        g = generators[idx]
        can_add = g['max_power'] - g['power']
        
        if can_add > 0.0001 and remaining > 0:
            add = min(can_add, remaining / sum(1 for gen in generators if gen['max_power'] - gen['power'] > 0.0001))
            add = min(add, remaining)
            g['power'] += add
            remaining -= add
            distributed_this_round = True
    
    if not distributed_this_round:
        break

# Финальная корректировка для точного попадания в цель
current_total = sum(g['power'] for g in generators)
if abs(current_total - target_power) > 0.0001:
    # Находим генератор с запасом
    for g in generators:
        diff = target_power - current_total
        can_add = g['max_power'] - g['power']
        can_subtract = g['power'] - g['min_power']
        
        if diff > 0 and can_add > abs(diff):
            g['power'] += diff
            break
        elif diff < 0 and can_subtract > abs(diff):
            g['power'] += diff  # diff отрицательный
            break

# Вывод результатов
print("\n" + "=" * 100)
print(f"{'Ген.':^6} {'Макс':^10} {'Мощность':^12} {'% Использов.':^15} {'Статус':^10}")
print("=" * 100)

total_power = 0
all_ok = True
for g in generators:
    percent = (g['power'] / g['max']) * 100
    total_power += g['power']
    in_range = min_percent*100 <= percent <= max_percent*100
    status = "✓ OK" if in_range else "✗ ERROR"
    if not in_range:
        all_ok = False
    print(f"{g['id']:^6} {g['max']:^10} {g['power']:^12.6f} {percent:^15.6f} {status:^10}")

print("=" * 100)
overall_percent = (total_power / total_max) * 100
print(f"{'ИТОГО':^6} {total_max:^10} {total_power:^12.6f} {overall_percent:^15.6f}")
print("=" * 100)
print(f"\nВсе генераторы в диапазоне: {all_ok}")
print(f"Целевой процент: {target_percent*100:.5f}%")
print(f"Фактический процент: {overall_percent:.5f}%")
print(f"Отклонение: {abs(overall_percent - target_percent*100):.8f}%")