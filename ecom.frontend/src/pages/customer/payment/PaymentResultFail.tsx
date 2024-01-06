import { Button, Card, Col, Image, List, Result, Row, Space, Spin, Typography } from 'antd'
import { useNavigate } from 'react-router-dom';


const PaymentResultFail = () => {
  const nav = useNavigate();

  return (
    (<div className='centerflex' style={{ flexDirection: 'column', rowGap: 50, padding: '20px 0' }}>

      <Card bordered >
        <Result
          status="error"
          title="Đã có lỗi xảy ra khi thanh toán."
          subTitle={<Space direction='vertical'>
            <p>Vui lòng liên hệ cửa hàng để hỗ trợ, hãy liên lạc với của hàng qua số điện thoại 0912324274</p>
          </Space>}
          extra={[
            <Button type="primary" key="console" onClick={() => nav("/")}>
              Về trang chủ
            </Button>
          ]}
        />
      </Card>
    </div >)
  )
}

export default PaymentResultFail