import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import React from 'react'
import DataTable from './dataTable'

const ParamPage = () => {
  return (
    <section className='p-5 bg-gray-200 min-h-screen font-sans'>
        <div>
            <div className='pt-4 text-3xl font-bold font-sans text-neutral-700'>
                Master Parameter
            </div>
            <h2 className='text-gray-500'>Manage parameter data</h2>
            <div className='max-w-7xl mx-auto bg-white rounded-lg shadow-md p-6 mt-4'>
                <div>
                    <DataTable/>
                </div>
            </div>
        </div>
    </section>
  )
}

export default ParamPage