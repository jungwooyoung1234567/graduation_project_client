참고: Form1은 모터 제어 전용 폼이므로  변경하지 않아도 돼요


참고: Form2는 MJPEG 스트리밍을 수신해서 화면에 출력하는 폼입니다.
코드 내 streamUrl 변수만 본인이 사용하는 스트리밍 주소로 교체하면 그대로 작동합니다.
다른 부분은 수정하지 않아도 돼요.


참고: Form3은 녹음된 음성을 HTTP POST 방식으로 라즈베리파이로 전송합니다.
WAV 포맷으로 인코딩된 데이터를 audio/wav 형식으로 전송하며, 라즈베리파이는 이를 HTTP로 수신하고 .wav 파일로 코드를 만들어야 정상적으로 재생 및 처리할 수 있습니다.
전송 주소는 기본적으로 http://127.0.0.1:12345/audio로 설정되어 있으며, 라즈베리파이의 실제 IP 주소에 맞게 수정해주셔야 합니다.
그 외 코드는 변경하지 않아도 돼요.

Form3은 백그라운드에서 HTTP 요청을 수신하며,
라즈베리파이에서 http://<PC_IP>:5000/receive/로 POST 요청을 보낼 때
본문에 "11111"이라는 문자열이 포함되면 사이렌을 재생합니다.
"11111"이 수신될때 사이렌이 재생되니까 조건을 바꾸셔도돼요

!!궁금한거 있으시면 질문주세요!!
