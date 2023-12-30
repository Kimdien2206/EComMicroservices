import { Button, Result } from 'antd'
import React from 'react'

const NotFoundResult = ({ message }: { message: string }) => {
  return (
    <Result
      status="404"
      title="404"
      subTitle={message}
      extra={<a href='/'><Button type="primary">Trở lại trang chủ</Button></a>}
    />
  )
}

export default NotFoundResult