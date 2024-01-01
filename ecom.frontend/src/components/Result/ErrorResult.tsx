import { Button, Result } from 'antd'
import React from 'react'
import { Link, useNavigate } from 'react-router-dom'

const ErrorResult = () => {
  const navigate = useNavigate();
  return (
    <Result
      status="500"
      title="Lỗi!!"
      subTitle="Đã xảy ra lỗi, xin hãy thử lại."
      extra={<a href='/'><Button type="primary">Trở lại</Button></a>}
    />
  )
}

export default ErrorResult