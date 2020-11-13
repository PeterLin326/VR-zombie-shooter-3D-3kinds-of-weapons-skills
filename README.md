# VR-zombie-shooter
게임 프로그래밍 수업과정에서 완성한 작업입니다. VR 기술을 사용하여 프로그래밍 언어는 C #입니다.

zombie의 주요 인공지능알고리즘과 무기의 기능을 올렸습니다. 


C# 무기 기능 3가지 구현입니다.

1.단발 2.연발 3.범위공격

범위공격 주요점: private static LineRenderer GetLineRenderer(Transform t) { LineRenderer lr = t.GetComponent(); if (lr == null) { lr = t.gameObject.AddComponent(); } lr.SetWidth(0.1f, 0.1f); return lr; }
