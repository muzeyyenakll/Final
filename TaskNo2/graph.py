import pandas as pd
import matplotlib.pyplot as plt

# CSV dosyasını okuma
df = pd.read_csv('avg_days.csv')


print(df)

plt.bar(df['Category'], df['AverageDays'])
plt.xlabel('Category')
plt.ylabel('Average Days')
plt.title('Average Days per Category')
plt.show()