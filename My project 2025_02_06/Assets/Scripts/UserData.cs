using UnityEngine;

// 클래스에 대한 직렬화
[System.Serializable]
public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    // 생성자(Constructor)
    // 클래스의 이름과 동일한 메소드를 의미
    // 반환 타입이 따로 없는 메소드
    // 따로 설정하지 않으면 기본 생성자로 처리됨

    // 기본 생성자 = 클래스의 이름과 동일한 메소드, 매개변수를 따로 받지 않음.
    public UserData()
    {

    }

    // 아이디, 이름, 비밀번호, 이메일 순선대로 작성하면 생성할수 있는 UserData 
    public UserData(string userID, string userName, string userPassword, string userEmail)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }

    /// <summary>
    /// 데이터를 하나의 문자열로 return 하는 코드
    /// </summary>
    /// <returns>아이디, 이름, 비밀번호, 이메일 순으로 처리</returns>
    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail}";
    // 1줄짜리 return 코드를 적을 경우 {} 대신 => 로 작성이 가능


    /// <summary>
    /// 데이터에 대한 정보를 전달 받고 UserData로 return하는 코드
    /// </summary>
    /// <param name="data"> 아이디,이름,비밀번호,이메일 순으로 작성된 데이터 </param>
    /// <returns></returns>
    public static UserData SetData(string data)
    {
        string[] data_value = data.Split(',');
        // 문자열.Split(',') : 해당 문자열을 ()안에 넣어준 ,를 기준으로 잘라서 배열로 만들어줌
        // 배열은 0번부터 데이터를 체크함(인덱스)

        return new UserData(data_value[0], data_value[1], data_value[2], data_value[3]);
    }
}
