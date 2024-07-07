from flask import Flask, render_template, request

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def calculate_average():
    if request.method == 'POST':
        num1 = float(request.form['num1'])
        num2 = float(request.form['num2'])
        average = (num1 + num2) / 2
        return render_template('result.html', average=average)
    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=True)
